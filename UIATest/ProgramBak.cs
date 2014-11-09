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
    class ProgramBak
    {
        static void Main11(string[] args)
        {
            //Process process = Process.Start(@"F:\CSharpDotNet\AutomationTest\ATP\WpfApp\bin\Debug\WpfApp.exe");
            Process process = Process.Start(@"F:\CSharpDotNet\AutomationTest\ATP\ATP.TestForm\bin\Debug\ATP.TestForm.exe");
            int processId = process.Id;
            Thread.Sleep(1000);

            AutomationElement element = FindElementById(processId, "textBox1");
            element.SetFocus();
            
            //ClickButtonById(processId, "button1");
            //ClickLeftMouse(processId, "button1");
            System.Windows.Forms.SendKeys.SendWait("{Enter}");
            Thread.Sleep(3000);

            //ClickButtonById(processId, "2");
            //ClickLeftMouse(processId, "2");
            System.Windows.Forms.SendKeys.SendWait("{Enter}");
            Thread.Sleep(1000);
            System.Windows.Forms.SendKeys.SendWait("adbad");
            Console.WriteLine("Test finised.");
            #region GridPattern Test
            
            //AutomationElement element = FindElementById(processId, "listview1");
            //GridPattern pattern = GetGridPattern(element);
            ////Get cell element which row and column is 1
            //AutomationElement tempElement = pattern.GetItem(1, 1);

            //Console.WriteLine("Cell which row = '{0}', column = '{1}', cell value is '{2}'",
            //    1, 1, tempElement.Current.Name);
            //Console.WriteLine("Grid row count = '{0}', column count = '{1}'",
            //    pattern.Current.RowCount, pattern.Current.ColumnCount);

            #endregion

            #region ScrollPattern
            //AutomationElement element = FindElementById(processId, "listview1");
            //AutomationElementCollection elementCollection=element.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty,ControlType.DataItem));

            //ScrollPattern scrollPattern = GetScrollPattern(element);

            //if (scrollPattern.Current.VerticallyScrollable)
            //{
            //    while (elementCollection[22].Current.IsOffscreen)
            //    {
            //        scrollPattern.ScrollVertical(ScrollAmount.LargeIncrement);
            //    }
            //}
            #endregion
            
        }

        public static void ClickButtonById(int processId, string buttonId)
        {
            AutomationElement element = FindElementById(processId, buttonId);
            if (element == null)
            {
                throw new NullReferenceException(string.Format("Element with AutomationId '{0}' can not be find.", element.Current.Name));
            }
            GetInvokePattern(element).Invoke();
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

        public object SendCtrlKey(bool isKeyDown)
        {
            if (!isKeyDown)
            {
                keybd_event(17, MapVirtualKey(17, 0), 0x2, 0);//Up CTRL key 
            }
            else
            {
                keybd_event(17, MapVirtualKey(17, 0), 0, 0); //Down CTRL key
            }
            return null;
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
        public static void ClickLeftMouse(int processId, string automationId)
        {
            AutomationElement element = FindElementById(processId, automationId);

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

        /// <summary>
        /// Bulk select the list item
        /// </summary>
        /// <param name="indexes">List item index collection</param>
        /// <param name="processId">Application process Id</param>
        /// <param name="isSelectAll">Is select all or not</param>
        public static void MutlSelect(int[] indexes, int processId, bool isSelectAll)
        {
            AutomationElement targetElement = FindElementById(processId, "listView1");

            AutomationElementCollection rows =
                targetElement.FindAll(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem));

            object multiSelect;

            if (isSelectAll)
            {
                for (int i = 1; i < rows.Count - 1; i++)
                {
                    if (rows[i].TryGetCurrentPattern(SelectionItemPattern.Pattern, out multiSelect))
                    {
                        (multiSelect as SelectionItemPattern).AddToSelection();
                    }
                }
            }
            else
            {
                if (indexes.Length > 0)
                {
                    for (int j = 0; j < indexes.Length; j++)
                    {
                        int tempIndex = indexes[j];
                        if (rows[tempIndex].TryGetCurrentPattern(SelectionItemPattern.Pattern, out multiSelect))
                        {
                            (multiSelect as SelectionItemPattern).AddToSelection();
                        }
                    }
                }
            }
        }

        #region GetScrollPattern helper
        /// <summary>
        /// Get ScrollPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>ScrollPattern instance</returns>
        public static ScrollPattern GetScrollPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ScrollPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ScrollPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as ScrollPattern;
        }

        #endregion

        #region GridPattern helper
        /// <summary>
        /// Get GridPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>GridPattern instance</returns>
        public static GridPattern GetGridPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(GridPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the GridPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as GridPattern;
        }

        #endregion

        #region SelectItemPattern

        /// <summary>
        /// Get SelectItemPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>SelectItemPattern instance</returns>
        public static SelectionItemPattern GetSelectionItemPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the SelectionItemPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as SelectionItemPattern;
        }

        #endregion

        #region TogglePattern helper

        /// <param name="element">AutomationElement instance</param>
        /// <returns>TogglePattern instance</returns>
        public static TogglePattern GetTogglePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(TogglePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the TogglePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as TogglePattern;
        }

        #endregion

        #region WindowPattern helper

        /// <summary>
        /// Get WindowPattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>WindowPattern instance</returns>
        public static WindowPattern GetWindowPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(WindowPattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the WindowPattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as WindowPattern;
        }


        #endregion

        #region ValuePattern helper

        /// <summary>
        /// To get the ValuePattern
        /// </summary>
        /// <param name="element">Target element</param>
        /// <returns>ValuePattern instance</returns>
        public static ValuePattern GetValuePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ValuePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ValuePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as ValuePattern;
        }

        #endregion

        #region InvokePattern helper
        /// <summary>
        /// Get InvokePattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>InvokePattern instance</returns>
        public static InvokePattern GetInvokePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(InvokePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the InvokePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as InvokePattern;
        }

        #endregion

        #region ExpandCollapsePattern helper

        /// <summary>
        /// Get ExpandCollapsePattern
        /// </summary>
        /// <param name="element">AutomationElement instance</param>
        /// <returns>ExpandCollapsePattern instance</returns>
        public static ExpandCollapsePattern GetExpandCollapsePattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out currentPattern))
            {
                throw new Exception(string.Format("Element with AutomationId '{0}' and Name '{1}' does not support the ExpandCollapsePattern.",
                    element.Current.AutomationId, element.Current.Name));
            }
            return currentPattern as ExpandCollapsePattern;
        }

        #endregion
    }
}