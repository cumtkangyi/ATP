using System;
using System.Windows.Automation;
using ATP.Core;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows;

namespace ATP.CoreLibs.Actions
{
    public class ClickLeftMouse :UIWindowAndElement, IUIAutomationRunner
    {
        #region Common
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
        /// <param name="a">MouseEventFlag </param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        [DllImport("user32.dll")]
        extern static void mouse_event(int a, int x, int y, int d, int e);

        const int MOUSEEVENTF_MOVE = 0x0001;
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        #endregion        
        
        #region Fileds

        Rect rect;

        #endregion

        #region Properties

        public bool IsSetPostion { get; set; }
        public bool IsFindByUser { get; set; }
        public int IncrementX { get; set; }
        public int IncrementY { get; set; }
        public AutomationElement targetElement { get; set; }
        
        #endregion

        #region IAction Members

        public object Execute(IUIAutomationRunner runner)
        {
            AutomationElement element = null; 
            if (IsFindByUser != true)
            {
                element = UIAutomationHelper.FindWindowControl(this, ControlType.Button, this.TimeOut);
            }
            else
            {
                element = targetElement;
            }

            if (element == null)
            {
                throw new NullReferenceException(string.Format("Element with AutomationId '{0}' and Name '{1}' can not be find.",
                    element.Current.AutomationId, element.Current.Name));
            }

            rect = element.Current.BoundingRectangle;

            if (IsSetPostion != true)
            {
                IncrementX = (int)(rect.Left + rect.Width / 2);
                IncrementY = (int)(rect.Top + rect.Height / 2);
            }
            else
            {
                IncrementX = (int)(rect.X + IncrementX);
                IncrementY = (int)(rect.Y + IncrementY);
            }
            //Make the cursor position to the element.
            SetCursorPos(IncrementX, IncrementY);
            Thread.Sleep(500);
            //Make the left mouse down and up.
            mouse_event(MOUSEEVENTF_LEFTDOWN, IncrementX, IncrementY, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, IncrementX, IncrementY, 0, 0);

            return null;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose();
        }

        #endregion

        #region Public Method

        public override string ToString()
        {
            return string.Format("Action name is '{0}', windowName is '{1}', processId is '{2}', element name is '{3}', the control type is '{4}', time out is '{5}'",
                this.GetType().Name, this.WindowName, this.ProcessId, this.ControlName, ControlType.Button, this.TimeOut);
        }

        #endregion
    }
}
