using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace ATP.Core
{
    public class PropertyConditions
    {
        static PropertyCondition propertyCondition;

        /// <summary>
        /// Create PropertyCondition by AutomationId
        /// </summary>
        /// <param name="automationId">Control AutomationId</param>
        /// <returns>Return PropertyCondition instance</returns>
        public static PropertyCondition GetAutomationIdProperty(object automationId)
        {
            propertyCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, automationId);
            return propertyCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static PropertyCondition GetControlTypeProperty(object controlType)
        {
            propertyCondition = new PropertyCondition(AutomationElement.ControlTypeProperty, controlType);
            return propertyCondition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public static PropertyCondition GetNameProperty(object controlName)
        {
            propertyCondition = new PropertyCondition(AutomationElement.NameProperty, controlName);
            return propertyCondition;
        }

        /// <summary>
        /// Find element by specific PropertyCondition
        /// </summary>
        /// <param name="condition">PropertyCondition instance</param>
        /// <returns>Target automation element</returns>
        public static AutomationElement FindElement(PropertyCondition condition)
        {
            return AutomationElement.RootElement.FindFirst(TreeScope.Descendants, condition);
        }
    }
}
