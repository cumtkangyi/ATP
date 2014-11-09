using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using ATP.Core;

namespace ATP.CoreLibs.Actions
{
    public class ClickMenu:UIWindowAndElement,IUIAutomationRunner
    {
        #region IUIAutomationRunner Members

        public object Execute(IUIAutomationRunner action)
        {
            AutomationElement element = UIAutomationHelper.FindWindowControl(this, ControlType.MenuItem, this.TimeOut);

            if (element == null)
            {
                throw new NullReferenceException(string.Format("Menu element with AutomationId '{0}' and Name '{1}' can not be find.",
                    element.Current.AutomationId, element.Current.Name));
            }

            ThreadStart threadStart = delegate
                {
                    PatternOperator.Invoke(element);
                };
            new Thread(threadStart).Start();
            Thread.Sleep(0xbb8);
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
                this.GetType().Name, this.ProcessId, this.ControlName, ControlType.MenuItem, this.TimeOut);
        }

        #endregion
    }
}
