using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using ATP.Core;

namespace ATP.CoreLibs
{
    public static class AppendTextToTextBoxExtension
    {

        static AutomationElement userForm = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tester"></param>
        /// <param name="processId"></param>
        /// <param name="automationId"></param>
        /// <param name="setValue"></param>
        public static void AppendTextToTextBoxById(this UIAutomationFacade facade, int processId, string automationId, string appendValue)
        {
        }

        public static void AppendTextToTextBoxByName(this UIAutomationFacade facade, int processId, string automationId, string appendValue)
        {
            
        }
    }
}
