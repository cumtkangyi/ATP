using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATP.Core
{
    public static class ClickButtonExtension
    {
        // Methods
        public static void ClickButtonAsyncById(this UIAutomationFacade facade, int processId, string automationId)
        {
            facade.Runner.UIAutomation().ClickButtonAsyncById(processId, automationId, 0xea60);
        }

        public static void ClickButtonAsyncById(this UIAutomationFacade facade, string windowName, string automationId)
        {
            facade.Runner.UIAutomation().ClickButtonAsyncById(windowName, automationId, 0xea60);
        }

        public static void ClickButtonAsyncById(this UIAutomationFacade facade, int processId, string automationId, int timeout)
        {
            ClickButton action = new ClickButton();
            action.ProcessId = processId;
            action.AutomationId = automationId;
            action.Timeout = timeout;
            action.IsSynchronous = false;
            facade.Runner.Execute(action);
        }

        public static void ClickButtonAsyncById(this UIAutomationFacade facade, string windowName, string automationId, int timeout)
        {
            ClickButton action = new ClickButton();
            action.WindowName = windowName;
            action.AutomationId = automationId;
            action.Timeout = timeout;
            action.IsSynchronous = false;
            facade.Runner.Execute(action);
        }

        public static void ClickButtonAsyncByName(this UIAutomationFacade facade, int processId, string name)
        {
            facade.Runner.UIAutomation().ClickButtonAsyncByName(processId, name, 0xea60);
        }

        public static void ClickButtonAsyncByName(this UIAutomationFacade facade, string windowName, string name)
        {
            facade.Runner.UIAutomation().ClickButtonAsyncByName(windowName, name, 0xea60);
        }

        public static void ClickButtonAsyncByName(this UIAutomationFacade facade, int processId, string name, int timeout)
        {
            ClickButton action = new ClickButton();
            action.ProcessId = processId;
            action.Name = name;
            action.Timeout = timeout;
            action.IsSynchronous = false;
            facade.Runner.Execute(action);
        }

        public static void ClickButtonAsyncByName(this UIAutomationFacade facade, string windowName, string name, int timeout)
        {
            ClickButton action = new ClickButton();
            action.WindowName = windowName;
            action.Name = name;
            action.Timeout = timeout;
            action.IsSynchronous = false;
            facade.Runner.Execute(action);
        }

        public static void ClickButtonById(this UIAutomationFacade facade, int processId, string automationId)
        {
            facade.Runner.UIAutomation().ClickButtonById(processId, automationId, 0xea60);
        }

        public static void ClickButtonById(this UIAutomationFacade facade, string windowName, string automationId)
        {
            facade.Runner.UIAutomation().ClickButtonById(windowName, automationId, 0xea60);
        }

        public static void ClickButtonById(this UIAutomationFacade facade, int processId, string automationId, int timeout)
        {
            ClickButton action = new ClickButton();
            action.ProcessId = processId;
            action.AutomationId = automationId;
            action.Timeout = timeout;
            action.IsSynchronous = true;
            facade.Runner.Execute(action);
        }

        public static void ClickButtonById(this UIAutomationFacade facade, string windowName, string automationId, int timeout)
        {
            ClickButton action = new ClickButton();
            action.WindowName = windowName;
            action.AutomationId = automationId;
            action.Timeout = timeout;
            action.IsSynchronous = true;
            facade.Runner.Execute(action);
        }

        public static void ClickButtonByName(this UIAutomationFacade facade, int processId, string name)
        {
            facade.Runner.UIAutomation().ClickButtonByName(processId, name, 0xea60);
        }

        public static void ClickButtonByName(this UIAutomationFacade facade, string windowName, string name)
        {
            facade.Runner.UIAutomation().ClickButtonByName(windowName, name, 0xea60);
        }

        public static void ClickButtonByName(this UIAutomationFacade facade, int processId, string name, int timeout)
        {
            ClickButton action = new ClickButton();
            action.ProcessId = processId;
            action.Name = name;
            action.Timeout = timeout;
            action.IsSynchronous = true;
            facade.Runner.Execute(action);
        }

        public static void ClickButtonByName(this UIAutomationFacade facade, string windowName, string name, int timeout)
        {
            ClickButton action = new ClickButton();
            action.WindowName = windowName;
            action.Name = name;
            action.Timeout = timeout;
            action.IsSynchronous = true;
            facade.Runner.Execute(action);
        }
    }
}
