using System;
using System.Windows.Automation;
using ATP.Core;
using System.Threading;
using System.Runtime.InteropServices;
using ATP.CoreLibs.Actions;

namespace ATP.CoreLibs
{
    public static class ClickButtonExtension
    {
        public static void ClickButtonById(this UIAutomationFacade facade, int processId, string automationId)
        {
            ClickButton button = new ClickButton();
            button.ProcessId = processId;
            button.AutomationId = automationId;
            button.TimeOut = 0xea60;
            button.Execute(button);
        }

        public static void ClickButtonByName(this UIAutomationFacade facade, int processId, string controlName)
        {
            ClickButton button = new ClickButton();
            button.ProcessId = processId;
            button.ControlName = controlName;
            button.TimeOut = 0xea60;
            button.Execute(button);
        }

        public static void ClickButtonById(this UIAutomationFacade facade, int processId, string automationId, int timeOut)
        {
            ClickButton button = new ClickButton();
            button.ProcessId = processId;
            button.AutomationId = automationId;
            button.TimeOut = timeOut;
            button.Execute(button);
        }

        public static void ClickButtonByName(this UIAutomationFacade facade, int processId, string controlName, int timeOut)
        {
            ClickButton button = new ClickButton();
            button.ProcessId = processId;
            button.ControlName = controlName;
            button.TimeOut = timeOut;
            button.Execute(button);
        }
    }
}
