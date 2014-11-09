using System;
using System.Windows.Automation;
using ATP.Core;
using System.Threading;
using System.Runtime.InteropServices;
using ATP.CoreLibs.Actions;

namespace ATP.CoreLibs
{
    public static class ClickLeftMouseExtension
    {
        public static void ClickLeftMouseById(this NataiveMethodsFacade facade, int processId, string automationId)
        {
            ClickLeftMouseById(facade, processId, automationId, 0xae60);
        }

        public static void ClickLeftMouseByName(this NataiveMethodsFacade facade, int processId, string controlName)
        {
            ClickLeftMouseByName(facade, processId, controlName, 0xae60);
        }

        public static void ClickLeftMouseById(this NataiveMethodsFacade facade, int processId, string automationId, int timeOut)
        {
            ClickLeftMouse element = new ClickLeftMouse();
            element.ProcessId = processId;
            element.AutomationId = automationId;
            element.TimeOut = timeOut;
            element.Execute(element);
        }

        public static void ClickLeftMouseByName(this NataiveMethodsFacade facade, int processId, string controlName, int timeOut)
        {
            ClickLeftMouse element = new ClickLeftMouse();
            element.ProcessId = processId;
            element.ControlName = controlName;
            element.TimeOut = timeOut;
            element.Execute(element);
        }


        public static void ClickLeftMouseById(this NataiveMethodsFacade facade, string windowName, string automationId)
        {
            ClickLeftMouseById(facade, windowName, automationId, 0xea60);
        }

        public static void ClickLeftMouseByName(this NataiveMethodsFacade facade, string windowName, string controlName)
        {
            ClickLeftMouseByName(facade, windowName, controlName, 0xea60);
        }

        public static void ClickLeftMouseById(this NataiveMethodsFacade facade, string windowName, string automationId, int timeOut)
        {
            ClickLeftMouse element = new ClickLeftMouse();
            element.WindowName = windowName;
            element.AutomationId = automationId;
            element.TimeOut = timeOut;
            element.Execute(element);
        }

        public static void ClickLeftMouseByName(this NataiveMethodsFacade facade, string windowName, string controlName, int timeOut)
        {
            ClickLeftMouse element = new ClickLeftMouse();
            element.WindowName = windowName;
            element.ControlName = controlName;
            element.TimeOut = timeOut;
            element.Execute(element);
        }



        public static void ClickByLeftMouse(this NataiveMethodsFacade facade, AutomationElement targetElement, int incrementX, int incrementY)
        {
            ClickByLeftMouse(facade, targetElement, incrementX, incrementY, 0xea60);
        }

        public static void ClickByLeftMouse(this NataiveMethodsFacade facade, AutomationElement targetElement, int incrementX, int incrementY, int timeOut)
        {
            ClickLeftMouse element = new ClickLeftMouse();
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
