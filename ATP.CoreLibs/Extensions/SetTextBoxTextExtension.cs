using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;
using ATP.Core;

namespace ATP.CoreLibs
{
    public static class SetTextBoxTextExtension
    {
        static AutomationElement userForm = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tester"></param>
        /// <param name="processId"></param>
        /// <param name="automationId"></param>
        /// <param name="value"></param>
        public static void SetTextBoxTextById(this Tester tester, int processId, string automationId, string value)
        {
            
        }

        /// <summary>
        /// Set TextBox text by control Name.
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// <param name="controlName">Control name</param>
        /// <param name="value">Set text value</param>
        public static void SetTextBoxTextByName(int processId, string controlName, string value)
        {
            
        }
    }
}
