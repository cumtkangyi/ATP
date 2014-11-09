using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using ATP.Core;
using ATP.CoreLibs.Actions;

namespace ATP.CoreLibs
{
    public static class ClickMenuExtension
    {
        public static void ClickMenuById(this UIAutomationFacade facade, int processId, string automationId)
        {
            ClickMenu menu = new ClickMenu();
            menu.ProcessId = processId;
            menu.AutomationId = automationId;
            menu.TimeOut = 0xea60;
            menu.Execute(menu);
        }

        public static void ClickMenuByName(this UIAutomationFacade facade, int processId, string controlName)
        {
            ClickMenu menu = new ClickMenu();
            menu.ProcessId = processId;
            menu.ControlName = controlName;
            menu.TimeOut = 0xea60;
            menu.Execute(menu);
        }

        public static void ClickMenuById(this UIAutomationFacade facade, int processId, string automationId, int timeOut)
        {
            ClickMenu menu = new ClickMenu();
            menu.ProcessId = processId;
            menu.AutomationId = automationId;
            menu.TimeOut = timeOut;
            menu.Execute(menu);
        }

        public static void ClickMenuByName(this UIAutomationFacade facade, int processId, string controlName, int timeOut)
        {
            ClickMenu menu = new ClickMenu();
            menu.ProcessId = processId;
            menu.ControlName = controlName;
            menu.TimeOut = timeOut;
            menu.Execute(menu);
        }
    }
}
