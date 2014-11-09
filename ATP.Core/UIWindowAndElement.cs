using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATP.Core
{
    public class UIWindowAndElement:IUIWindowAndElement
    {
        #region IUIElementAction Members

        /// <summary>
        /// Element AutomationId property
        /// </summary>
        private string automationId;
        public string AutomationId
        {
            get { return this.automationId; }
            set { this.automationId = value; }
        }

        /// <summary>
        /// Window Name property
        /// </summary>
        private string windowName;
        public string WindowName
        {
            get { return this.windowName; }
            set { this.windowName = value; }
        }

        /// <summary>
        /// Control Name property
        /// </summary>
        private string controlName;
        public string ControlName
        {
            get { return this.controlName; }
            set { this.controlName = value; }
        }

        /// <summary>
        /// App processId property
        /// </summary>
        private int processId;
        public int ProcessId
        {
            get { return this.processId; }
            set { this.processId = value; }
        }

        private int timeOut;
        public int TimeOut
        {
            get { return this.timeOut; }
            set { this.timeOut = value; }
        }

        #endregion
    }
}
