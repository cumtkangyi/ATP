using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATP.Core;

namespace ATP.CoreLibs
{
    public class UIAutomationFacade
    {
        public IUIAutomationRunner AutomationRunner { get; private set; }
        public UIAutomationFacade(IUIAutomationRunner automationRunner)
        {
            if (null == automationRunner)
            {
                throw new ArgumentNullException("automationRunner is null.");
            }
            AutomationRunner = automationRunner;
        }
    }
}
