/*************************************************************************
 * 
 * Summary: This class used to get element by automatio Id or name.
 * Update Date: 2009-7-11 14:25
 * Version:
 * 
 * ***********************************************************************/

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;

namespace UIATest
{
    /// <summary>
    /// Get the element by automation Id or control name.
    /// </summary>
    public static class FindElement
    {
        static AutomationElement aeForm = null;

        /// <summary>
        /// Get the automation element by automation Id.
        /// </summary>
        /// <param name="windowName">Window name</param>
        /// <param name="automationId">Control automation Id</param>
        /// <returns>Automatin element searched by automation Id</returns>
        public static AutomationElement FindElementById(string windowName, string automationId)
        {
            aeForm = AutomationElementHelper.FindWindowByWindowName(windowName);
            AutomationElement tarFindElement = aeForm.FindFirst(TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
            return tarFindElement;
        }

        /// <summary>
        /// Get the automation element by Automation Id and process Id.
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// <param name="controlName">Control Name</param>
        /// <returns>Automatin element searched by control name</returns>
        public static AutomationElement FindElementByName(int processId, string controlName)
        {
            aeForm = AutomationElementHelper.FindWindowByProcessId(processId);
            AutomationElement tarFindElement = aeForm.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, controlName));
            return tarFindElement;
        }

        /// <summary>
        /// Get the automation element by Automation Id.
        /// </summary>
        /// <param name="windowName">Window name</param>
        /// <param name="controlName">Control Name</param>
        /// <returns>Automatin element searched by control name</returns>
        public static AutomationElement FindElementByName(string windowName, string controlName)
        {
            aeForm = AutomationElementHelper.FindWindowByWindowName(windowName);
            AutomationElement tarFindElement = aeForm.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.NameProperty, controlName));
            return tarFindElement;
        }
    }
}
