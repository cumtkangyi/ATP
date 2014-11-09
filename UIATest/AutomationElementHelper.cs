using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Automation;

namespace UIATest
{
    /// <summary>
    /// To get the automation element.
    /// </summary>
    public class AutomationElementHelper
    {
        #region Fileds

        static AutomationElement targetWindow;

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public static AutomationElement TargetWindow
        {
            get 
            {
                if (targetWindow != null)
                    return targetWindow;
                else
                    return null;
            }
            set
            {
                targetWindow = value;
            }
        }

        #endregion

        #region Method
        /// <summary>
        /// Get the automation elemention of current form.
        /// </summary>
        /// <param name="processName">The current program process name.</param>
        /// <returns>An automation element.</returns>
        public static AutomationElement FindWindowByProcessName(string processName)
        {
            Process[] p = Process.GetProcessesByName(processName);
            if (p.Count() == 0)
            {
                throw new InvalidProgramException("Target window is not existing ,please run the program and  try it again");

            }
            TargetWindow = AutomationElement.FromHandle(p[0].MainWindowHandle);
            return TargetWindow;
        }

        /// <summary>
        /// Get the automation elemention of current form.
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// <returns>Target element</returns>
        public static AutomationElement FindWindowByProcessId(int processId)
        {
            try
            {
                Process p = Process.GetProcessById(processId);
                TargetWindow = AutomationElement.FromHandle(p.MainWindowHandle);
                return TargetWindow;
            }
            catch (Exception)
            {
                throw new InvalidProgramException("Target window is not existing ,please run the program and  try it again");
            }
        }

        /// <summary>
        /// Find target window by window name.
        /// </summary>
        /// <param name="windowName">Window name</param>
        /// <returns>Return target window element</returns>
        public static AutomationElement FindWindowByWindowName(string windowName)
        {
            try
            {
                AutomationElement element = AutomationElement.RootElement;
                Condition nameCondition = new PropertyCondition(AutomationElement.NameProperty,windowName);
                TargetWindow = element.FindFirst(TreeScope.Descendants, nameCondition);
                return TargetWindow;
            }
            catch (Exception)
            {
                throw new InvalidProgramException("Target window is not existing ,please run the program and  try it again");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="processName"></param>
        /// <param name="windowName"></param>
        /// <returns></returns>
        public static AutomationElement FindWindow(int processId, string processName, string windowName)
        {
            AutomationElement element = null;
            if (processId != 0)
            {
                element = FindWindowByProcessId(processId);
            }
            if (element == null && processName != null)
            {
                element = FindWindowByProcessName(processName);
            }
            if (element == null && windowName != null)
            {
                element = FindWindowByWindowName(windowName);
            }
            if (element == null)
            {
                throw new InvalidOperationException(string.Format("Can not find window which processId is '{0}', window name is '{1}'", processId, windowName));
            }
            return element;
        }

        #endregion

        #region Public Method

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Target window processId is '{0}', target window name is '{1}'",targetWindow.Current.ProcessId, targetWindow.Current.Name);
        }

        #endregion
    }
}
