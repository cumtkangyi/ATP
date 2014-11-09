using System;
using System.Collections.Generic;
using ATP.CoreLibs.Actions;

namespace ATP.CoreLibs
{
    public static class SendKeysExtension
    {
        // Methods
        public static void SendKeys(this UIAutomationFacade facade, int processId, params string[] keys)
        {
             facade.SendKeys(processId, 0xea60, keys);
        }

        public static void SendKeys(this UIAutomationFacade facade, string windowName, params string[] keys)
        {
            facade.SendKeys(windowName, 0xea60, keys);
        }

        public static void SendKeys(this UIAutomationFacade facade, int processId, int timeout, params string[] keys)
        {
            SendKeys action = new SendKeys();
            action.ProcessId = processId;
            action.Keys = keys;
            action.Timeout = timeout;
            action.Execute(action);
        }

        public static void SendKeys(this UIAutomationFacade facade, string windowName, int timeout, params string[] keys)
        {
            SendKeys action = new SendKeys();
            action.WindowName = windowName;
            action.Keys = keys;
            action.Timeout = timeout;
            action.Execute(action);
        }

    }
}
