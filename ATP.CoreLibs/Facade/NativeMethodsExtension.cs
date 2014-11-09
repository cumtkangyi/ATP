using System;
using ATP.Core;

namespace ATP.CoreLibs
{
    public static class NatamethodsExtension
    {
        public static NataiveMethodsFacade NativeMethods(this IUIAutomationRunner runner)
        {
            return new NataiveMethodsFacade(runner);
        }
    }
}
