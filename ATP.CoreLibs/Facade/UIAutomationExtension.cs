using System;
using ATP.Core;

namespace ATP.CoreLibs
{
    public static class UIAutomationExtension
    {
        public static UIAutomationFacade UIAutomation(this IUIAutomationRunner runner)
        {
            return new UIAutomationFacade(runner);
        }
    }
}
