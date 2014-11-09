using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATP.Core;

namespace ATP.CoreLibs
{
    public class NataiveMethodsFacade
    {
        public IUIAutomationRunner AutomationRunner { get; private set; }
        public NataiveMethodsFacade(IUIAutomationRunner automationRunner)
        {
            if (null == automationRunner)
            {
                throw new ArgumentNullException("automationRunner is null.");
            }
            AutomationRunner = automationRunner;
        }
    }
}
