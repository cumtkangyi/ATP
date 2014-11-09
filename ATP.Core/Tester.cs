using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATP.Core;

namespace ATP.Core
{
    public class Tester:IUIAutomationRunner
    {
        public IUIAutomationRunner AutomationRunner { get; set; }

        UIAutomationRunner automationRunner = new UIAutomationRunner();
        public Tester()
        {
            AutomationRunner = automationRunner;
        }

        public Tester(IUIAutomationRunner automationRunner)
        {
            AutomationRunner = automationRunner;
        }

        #region IUIAutomationRunner Members

        public object Execute(IUIAutomationRunner automationRunner)
        {
            AutomationRunner.Execute(automationRunner);
            return null;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose();
        }

        #endregion
    }
}
