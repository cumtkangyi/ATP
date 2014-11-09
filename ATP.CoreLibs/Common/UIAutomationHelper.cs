using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using ATP.Core;

namespace ATP.CoreLibs
{
    #region Delegate

    public delegate IList<AutomationElement> FindWindowsDelegate(int processId, string windowName);
    public delegate AutomationElement FindControlElementDelegate(AutomationElement parent, string controlName, string controlAutomationId, ControlType type);
    
    #endregion Delegate

    internal static class UIAutomationHelper
    {
        #region Fields
        public const int Timeout = 0xea60;

        #endregion Fields

        #region Methods
        /// <summary>
        /// Find control by controlName, control AutomationId or control Type.
        /// </summary>
        /// <param name="parent">The parent element</param>
        /// <param name="controlName">Control name property</param>
        /// <param name="controlAutomationId">Control AutomationId property</param>
        /// <param name="controlType">Control type property</param>
        /// <returns>Return the target control</returns>
        public static AutomationElement FindControl(AutomationElement parent, string controlName, string controlAutomationId, ControlType controlType)
        {
            AutomationElement element = null;
            Condition condition;
            Condition controlTypecondition = null;
            if (parent == null)
            {
                parent = AutomationElement.RootElement;
            }
            if (controlType != null)
            {
                controlTypecondition = PropertyConditions.GetControlTypeProperty(controlType);
            }
            if (controlName != null)
            {
                Condition nameCondition = PropertyConditions.GetNameProperty(controlName);
                if (controlTypecondition != null)
                {
                    condition = new AndCondition(new Condition[] { controlTypecondition, nameCondition });
                }
                else
                {
                    condition = nameCondition;
                }
                return parent.FindFirst(TreeScope.Descendants, condition);
            }
            if (controlAutomationId == null)
            {
                return element;
            }
            Condition automationIdCondition = PropertyConditions.GetAutomationIdProperty(controlAutomationId);
            if (controlTypecondition != null)
            {
                condition = new AndCondition(new Condition[] { controlTypecondition, automationIdCondition });
            }
            else
            {
                condition = automationIdCondition;
            }
            return parent.FindFirst(TreeScope.Descendants, condition);
        }

        /// <summary>
        /// Find control by controlName, control AutomationId or control Type (Overload +1).
        /// </summary>
        /// <param name="parent">The parent element</param>
        /// <param name="controlName">Control name property</param>
        /// <param name="controlAutomationId">Control AutomationId property</param>
        /// <param name="controlType">Control type property</param>
        /// <param name="timeout">Time out</param>
        /// <returns>Return the target control</returns>
        private static AutomationElement FindControl(AutomationElement parent, string controlName, string controlAutomationId, ControlType controlType, int timeout)
        {
            AutomationElement element = null;
            DateTime time = DateTime.Now.AddMilliseconds((double) timeout);
            bool flag = false;
            while (!flag || (DateTime.Now <= time))
            {
                if (DateTime.Now > time)
                {
                    flag = true;
                }
                Thread.Sleep(200);
                element = FindControl(parent, controlName, controlAutomationId, controlType);
                if (element != null)
                {
                    return element;
                }
            }
            return null;
        }

        /// <summary>
        /// Find control by control AutomationId property.
        /// </summary>
        /// <param name="parent">The parent element</param>
        /// <param name="controlAutomationId">Control AutomationId property</param>
        /// <param name="controlType">ControlType property</param>
        /// <param name="timeout">Time out</param>
        /// <returns>Return the target element</returns>
        public static AutomationElement FindControlById(AutomationElement parent, string controlAutomationId, ControlType controlType, int timeout)
        {
            return FindControl(parent, null, controlAutomationId, controlType, timeout);
        }

        /// <summary>
        /// Find control by control AutomationId property.
        /// </summary>
        /// <param name="parent">The parent element</param>
        /// <param name="controlName">Control Name property</param>
        /// <param name="controlType">ControlType property</param>
        /// <param name="timeout">Time out</param>
        /// <returns>Return the target control</returns>
        public static AutomationElement FindControlByName(AutomationElement parent, string controlName, ControlType controlType, int timeout)
        {
            return FindControl(parent, controlName, null, controlType, timeout);
        }

        /// <summary>
        /// Find dialog by dialog title and dialog message.
        /// </summary>
        /// <param name="processID">The ProcessId</param>
        /// <param name="dialogTitle">The dialog title</param>
        /// <param name="dialogMessage">The dialog message</param>
        /// <param name="timeout">Time out.</param>
        /// <returns>If find the target dialog, return this dialog, or return the null instance</returns>
        public static AutomationElement FindDialog(int processID, string dialogTitle, string dialogMessage, int timeout)
        {
            AndCondition condition = new AndCondition(new Condition[] { new PropertyCondition(AutomationElement.NameProperty, dialogMessage), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text) });
            DateTime time = DateTime.Now.AddMilliseconds((double) timeout);
            bool flag = false;
            while (!flag || (DateTime.Now <= time))
            {
                if (DateTime.Now > time)
                {
                    flag = true;
                }
                Thread.Sleep(200);
                foreach (AutomationElement element in FindWindows(AutomationElement.RootElement, processID, dialogTitle))
                {
                    if (element.FindFirst(TreeScope.Children, condition) != null)
                    {
                        return element;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Find window by window action.
        /// </summary>
        /// <param name="action">IUIWindowAction instance</param>
        /// <param name="timeout">Time out</param>
        /// <returns>Return the target window</returns>
        public static AutomationElement FindWindow(IUIWindowAndElement action, int timeout)
        {
            return FindWindow(action.ProcessId, action.WindowName, timeout);
        }

        /// <summary>
        /// Find window by WindowName
        /// </summary>
        /// <param name="processId">The ProcessId</param>
        /// <param name="windowName">The window title</param>
        /// <param name="timeout">Time out</param>
        /// <returns>The target window</returns>
        private static AutomationElement FindWindow(int processId, string windowName, int timeout)
        {
            DateTime time = DateTime.Now.AddMilliseconds((double) timeout);
            bool flag = false;
            while (!flag || (DateTime.Now <= time))
            {
                if (DateTime.Now > time)
                {
                    flag = true;
                }
                Thread.Sleep(200);
                List<AutomationElement> source = FindWindows(AutomationElement.RootElement, processId, windowName);
                if (((source != null) && (source.Count<AutomationElement>() > 0)) && (source[0] != null))
                {
                    return source[0];
                }
            }
            return null;
        }

        /// <summary>
        /// Findow window by window AutomationId.
        /// </summary>
        /// <param name="automationId">Window AutomationId property</param>
        /// <param name="timeout">Time out</param>
        /// <returns>The target window</returns>
        public static AutomationElement FindWindowById(string automationId, int timeout)
        {
            return FindControlById(AutomationElement.RootElement, automationId, ControlType.Window, timeout);
        }

        /// <summary>
        /// Findow window by window Name.
        /// </summary>
        /// <param name="windowName">The window name</param>
        /// <param name="timeout">Time out</param>
        /// <returns>Return the target window</returns>
        public static AutomationElement FindWindowByName(string windowName, int timeout)
        {
            return FindWindow(-1, windowName, timeout);
        }

        /// <summary>
        /// Findow window control by control type.
        /// </summary>
        /// <param name="action">UIWindowElementAction instance</param>
        /// <param name="controlType">ControlType property</param>
        /// <param name="timeout">Time out</param>
        /// <param name="window">The out window</param>
        /// <returns>Return the target window</returns>
        public static AutomationElement FindWindowControl(UIWindowAndElement action, ControlType controlType, int timeout)
        {
            return FindWindowControl(action.ProcessId, action.WindowName, action.ControlName, action.AutomationId, controlType, timeout);
        }

        /// <summary>
        /// Find window control by window name, control name, control type, control AutomationId.
        /// </summary>
        /// <param name="processId">The ProcessId</param>
        /// <param name="windowName">The window Name property</param>
        /// <param name="controlName">The control Name property</param>
        /// <param name="controlAutomationId">The control AutomationId property</param>
        /// <param name="controlType">The ControlType property</param>
        /// <param name="timeout">Time out</param>
        /// <param name="window">The out window</param>
        /// <returns>Return the target window or null instance</returns>
        private static AutomationElement FindWindowControl(int processId, string windowName, string controlName, string controlAutomationId, ControlType controlType, int timeout)
        {
            AutomationElement window = null;
            DateTime time = DateTime.Now.AddMilliseconds((double) timeout);
            bool flag = false;
            while (!flag || (DateTime.Now <= time))
            {
                if (DateTime.Now > time)
                {
                    flag = true;
                }
                Thread.Sleep(200);
                foreach (AutomationElement element in FindWindows(AutomationElement.RootElement, processId, windowName))
                {
                    AutomationElement targetElement = FindControl(element, controlName, controlAutomationId, controlType);
                    window = element;
                    if (targetElement != null)
                    {
                        return targetElement;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Find window control by control AutomationId property.
        /// </summary>
        /// <param name="processId">The processId</param>
        /// <param name="controlAutomationId">The control AutomationId property</param>
        /// <param name="controlType">The ControlType property</param>
        /// <param name="timeout">The Time out</param>
        /// <param name="window">The out window</param>
        /// <returns>Return the target window</returns>
        public static AutomationElement FindWindowControlById(int processId, string controlAutomationId, ControlType controlType, int timeout)
        {
            return FindWindowControl(processId, null, null, controlAutomationId, controlType, timeout);
        }

        /// <summary>
        /// Find window control by control AutomationId property (overload +1).
        /// </summary>
        /// <param name="windowName">The window Name</param>
        /// <param name="controlAutomationId">The control AutomationId property</param>
        /// <param name="controlType">The ControlType property</param>
        /// <param name="timeout">The time out</param>
        /// <returns>Return the target window</returns>
        public static AutomationElement FindWindowControlById(string windowName, string controlAutomationId, ControlType controlType, int timeout)
        {
            return FindWindowControl(-1, windowName, null, controlAutomationId, controlType, timeout);
        }

        /// <summary>
        /// Find window control by control Name.
        /// </summary>
        /// <param name="processId">The processId</param>
        /// <param name="controlName">The control Name property</param>
        /// <param name="controlType">The ControlType property</param>
        /// <param name="timeout">The time out</param>
        /// <returns>Return the target control</returns>
        public static AutomationElement FindWindowControlByName(int processId, string controlName, ControlType controlType, int timeout)
        {
            return FindWindowControl(processId, null, controlName, null, controlType, timeout);
        }

        /// <summary>
        /// Find window control by control Name (overload +1).
        /// </summary>
        /// <param name="windowName">The window Name property</param>
        /// <param name="controlName">The control Name property</param>
        /// <param name="controlType">The ControlType property</param>
        /// <param name="timeout">The time out</param>
        /// <returns>Return the target control</returns>
        public static AutomationElement FindWindowControlByName(string windowName, string controlName, ControlType controlType, int timeout)
        {
            return FindWindowControl(-1, windowName, controlName, null, controlType, timeout);
        }

        /// <summary>
        /// Find the window collection by window Name.
        /// </summary>
        /// <param name="parent">The parent element</param>
        /// <param name="processId">The processId</param>
        /// <param name="windowName">The window Name property</param>
        /// <returns>Return the target window control</returns>
        private static List<AutomationElement> FindWindows(AutomationElement parent, int processId, string windowName)
        {
            List<AutomationElement> matchingWindows = new List<AutomationElement>();
            FindWindows(parent, processId, windowName, matchingWindows);
            return matchingWindows;
        }

        /// <summary>
        /// Find window collectiono by window Name (overlaod +1).
        /// </summary>
        /// <param name="parent">The parent element</param>
        /// <param name="processId">The processId</param>
        /// <param name="windowName">The window Name property</param>
        /// <param name="matchingWindows">The window collection</param>
        private static void FindWindows(AutomationElement parent, int processId, string windowName, 
            List<AutomationElement> matchingWindows)
        {
            TreeWalker controlViewWalker = TreeWalker.ControlViewWalker;
            if (parent != null)
            {
                for (AutomationElement element = controlViewWalker.GetFirstChild(parent); 
                    element != null; element = TreeWalker.ControlViewWalker.GetNextSibling(element))
                {
                    if (element.Current.ControlType == ControlType.Window)
                    {
                        if (windowName != null)
                        {
                            if (element.Current.Name == windowName)
                            {
                                matchingWindows.Add(element);
                            }
                        }
                        else if (element.Current.ProcessId == processId)
                        {
                            matchingWindows.Add(element);
                        }
                        FindWindows(element, processId, windowName, matchingWindows);
                    }
                }
            }
        }

        /// <summary>
        /// Get control
        /// </summary>
        /// <param name="parent">The parent element</param>
        /// <param name="controlName">The control Name property</param>
        /// <param name="controlAutomationId">The control AutomationId property</param>
        /// <param name="controlType">The ControlType property</param>
        /// <param name="timeout">The time out</param>
        /// <returns>Returnt the target element</returns>
        private static AutomationElement GetControl(AutomationElement parent, string controlName, string controlAutomationId, ControlType controlType, int timeout)
        {
            AutomationElement element = null;
            FindControlElementDelegate findControlElementDelegate = new FindControlElementDelegate(UIAutomationHelper.FindControl);
            IAsyncResult result = findControlElementDelegate.BeginInvoke(parent, controlName, controlAutomationId, controlType, null, null);
            if (result.AsyncWaitHandle.WaitOne(timeout, true))
            {
                element = findControlElementDelegate.EndInvoke(result);
            }
            return element;
        }

        #endregion Method
    }
}
