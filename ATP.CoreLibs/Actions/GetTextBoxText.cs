using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using ATP.Core;

namespace ATP.CoreLibs.Actions
{
    public class GetTextBoxText:UIWindowAndElement,IUIAutomationRunner
    {
        #region IUIAutomationRunner Members

        public object Execute(IUIAutomationRunner action)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
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
