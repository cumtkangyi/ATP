using System;
using System.Windows.Automation;
using ATP.Core;
using System.Threading;
using System.Runtime.InteropServices;
using ATP.CoreLibs;
using ATP.CoreLibs.Actions;

namespace ATP.CoreLibs
{
    public static class ClickRightMouseExtension
    {
        public static void ClickRightMouseById(this NataiveMethodsFacade facade, int processId, string automationId)
        {
            ClickRightMouseById(facade, processId, automationId, 0xea60);
        }

        public static void ClickRightMouseByName(this NataiveMethodsFacade facade, int processId, string controlName)
        {
            ClickRightMouseByName(facade, processId, controlName, 0xea60);
        }

        public static void ClickRightMouseById(this NataiveMethodsFacade facade, int processId, string automationId, int timeOut)
        {
            ClickRightMouse element = new ClickRightMouse();
            element.ProcessId = processId;
            element.AutomationId = automationId;
            element.TimeOut = timeOut;
            element.Execute(element);
        }

        public static void ClickRightMouseByName(this NataiveMethodsFacade facade, int processId, string controlName, int timeOut)
        {
            ClickRightMouse element = new ClickRightMouse();
            element.ProcessId = processId;
            element.ControlName = controlName;
            element.TimeOut = timeOut;
            element.Execute(element);
        }


        public static void ClickRightMouseById(this NataiveMethodsFacade facade, string windowName, string automationId)
        {
            ClickRightMouseById(facade, windowName, automationId, 0xea60);
        }

        public static void ClickRightMouseByName(this NataiveMethodsFacade facade, string windowName, string controlName)
        {
            ClickRightMouseByName(facade, windowName, controlName, 0xea60);
        }

        public static void ClickRightMouseById(this NataiveMethodsFacade facade, string windowName, string automationId, int timeOut)
        {
            ClickRightMouse element = new ClickRightMouse();
            element.WindowName = windowName;
            element.AutomationId = automationId;
            element.TimeOut = timeOut;
            element.Execute(element);
        }

        public static void ClickRightMouseByName(this NataiveMethodsFacade facade, string windowName, string controlName, int timeOut)
        {
            ClickRightMouse element = new ClickRightMouse();
            element.WindowName = windowName;
            element.ControlName = controlName;
            element.TimeOut = timeOut;
            element.Execute(element);
        }


        public static void ClickByRightMouse(this NataiveMethodsFacade facade, AutomationElement targetElement, int incrementX, int incrementY)
        {
            ClickByRightMouse(facade, targetElement, incrementX, incrementY, 0xea60);
        }

        public static void ClickByRightMouse(this NataiveMethodsFacade facade, AutomationElement targetElement, int incrementX, int incrementY, int timeOut)
        {
            ClickRightMouse element = new ClickRightMouse();
            element.IsFindByUser = true;
            element.IsSetPostion = true;
            element.targetElement = targetElement;
            element.IncrementX = incrementX;
            element.IncrementY = incrementY;
            element.TimeOut = timeOut;
            element.Execute(element);
        }
    }
}
