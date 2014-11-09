using System;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace UIATest
{
    class Program_simulateKeyboard
    {
        static void Main_simulateKeyboard(string[] args)
        {
            Process process = Process.Start(@"E:\WorkBook\ATP\WpfApp\bin\Debug\WpfApp.exe");
            //Process process = Process.Start(@"F:\CSharpDotNet\AutomationTest\ATP\ATP.TestForm\bin\Debug\ATP.TestForm.exe");
            int processId = process.Id;

            AutomationElement element = FindElementById(processId, "ListBox1");
            AutomationElementCollection listItems = element.FindAll(TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));

            SendCtrlKey(true);
            Thread.Sleep(500);
            ClickLeftMouse(listItems[0]);
            Thread.Sleep(500);
            ClickLeftMouse(listItems[2]);
            Thread.Sleep(500);
            ClickLeftMouse(listItems[3]);
            Thread.Sleep(500);
            ClickLeftMouse(listItems[5]);
            SendCtrlKey(false);

            //Note: The statement 'Thread.Sleep (500)' is to make each of these steps can be seen by tester.
            Console.WriteLine("Test finised.");   
        }

        #region Simulate keyboard
        /// <summary>
        /// Simulate the keyboard operations
        /// </summary>
        /// <param name="bVk">Virtual key value</param>
        /// <param name="bScan">Hardware scan code</param>
        /// <param name="dwFlags">Action flag</param>
        /// <param name="dwExtraInfo">Extension information which assication the keyborad action</param>
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        /// <summary>
        /// Map virtual key
        /// </summary>
        /// <param name="uCode">Virtual key code</param>
        /// <param name="uMap">Defines the translation to be performed</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern byte MapVirtualKey(uint uCode, uint uMap);

        public static void SendCtrlKey(bool isKeyDown)
        {
            if (!isKeyDown)
            {
                keybd_event(17, MapVirtualKey(17, 0), 0x2, 0);//Up CTRL key 
            }
            else
            {
                keybd_event(17, MapVirtualKey(17, 0), 0, 0); //Down CTRL key
            }
        }

        #endregion

        #region ClickMouse

        #region Import DLL
        /// <summary>
        /// Add mouse move event 
        /// </summary>
        /// <param name="x">Move to specify x coordinate</param>
        /// <param name="y">Move to specify y coordinate</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        extern static bool SetCursorPos(int x, int y);

        /// <summary>
        /// Mouse click event
        /// </summary>
        /// <param name="mouseEventFlag">MouseEventFlag </param>
        /// <param name="incrementX">X coordinate</param>
        /// <param name="incrementY">Y coordinate</param>
        /// <param name="data"></param>
        /// <param name="extraInfo"></param>
        [DllImport("user32.dll")]
        extern static void mouse_event(int mouseEventFlag, int incrementX, int incrementY, uint data, UIntPtr extraInfo);

        const int MOUSEEVENTF_MOVE = 0x0001;
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        #endregion  
        public static void ClickLeftMouse(AutomationElement element)
        {
            if (element == null)
            {
                throw new NullReferenceException(string.Format("Element with AutomationId '{0}' and Name '{1}' can not be find.",
                    element.Current.AutomationId, element.Current.Name));
            }

            Rect rect = element.Current.BoundingRectangle;
            int IncrementX = (int)(rect.Left + rect.Width / 2);
            int IncrementY = (int)(rect.Top + rect.Height / 2);

            //Make the cursor position to the element.
            SetCursorPos(IncrementX, IncrementY);

            //Make the left mouse down and up.
            mouse_event(MOUSEEVENTF_LEFTDOWN, IncrementX, IncrementY, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, IncrementX, IncrementY, 0, UIntPtr.Zero);
        }

        #endregion

        /// <summary>
        /// Get the automation elemention of current form.
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// <returns>Target element</returns>
        public static AutomationElement FindWindowByProcessId(int processId)
        {
            AutomationElement targetWindow = null;
            int count = 0;
            try
            {
                Process p = Process.GetProcessById(processId);
                targetWindow = AutomationElement.FromHandle(p.MainWindowHandle);
                return targetWindow;
            }
            catch (Exception ex)
            {
                count++;
                StringBuilder sb = new StringBuilder();
                string message = sb.AppendLine(string.Format("Target window is not existing.try #{0}", count)).ToString();
                if (count > 5)
                {
                    throw new InvalidProgramException(message, ex);
                }
                else
                {
                    return FindWindowByProcessId(processId);
                }
            }
        }

        /// <summary>
        /// Get the automation element by automation Id.
        /// </summary>
        /// <param name="windowName">Window name</param>
        /// <param name="automationId">Control automation Id</param>
        /// <returns>Automatin element searched by automation Id</returns>
        public static AutomationElement FindElementById(int processId, string automationId)
        {
            AutomationElement aeForm = FindWindowByProcessId(processId);
            AutomationElement tarFindElement = aeForm.FindFirst(TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
            return tarFindElement;
        }
    }
}