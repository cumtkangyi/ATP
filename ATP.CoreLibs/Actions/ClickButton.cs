using System;
using System.Windows.Automation;
using ATP.Core;
using System.Threading;
using System.Runtime.InteropServices;

namespace ATP.CoreLibs.Actions
{
    public class ClickButton :UIWindowAndElement, IUIAutomationRunner
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr PostMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        #region IAction Members

        public object Execute(IUIAutomationRunner runner)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControl(this, ControlType.Button, this.TimeOut);

            if (element == null)
            {
                throw new NullReferenceException(string.Format("Button element with AutomationId '{0}' and Name '{1}' can not be find.",
                    element.Current.AutomationId, element.Current.Name));
            }

            ThreadStart start2 = null;
            IntPtr nativeWindowHandle = (IntPtr)element.Current.NativeWindowHandle;
            if (nativeWindowHandle != IntPtr.Zero)
            {
                HandleRef hWnd = new HandleRef(nativeWindowHandle, nativeWindowHandle);
                PostMessage(hWnd, 0xf5, IntPtr.Zero, IntPtr.Zero);
            }
            else
            {
                if (start2 == null)
                {
                    start2 = delegate
                    {
                        PatternOperator.Invoke(element);
                    };
                }
                ThreadStart start = start2;
                new Thread(start).Start();
                Thread.Sleep(0xbb8);
            }
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
