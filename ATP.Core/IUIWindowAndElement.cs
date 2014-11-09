using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATP.Core
{
    public interface IUIWindowAndElement
    {
        #region Properties

        int ProcessId { get; }
        string AutomationId { get; }
        string WindowName { get;  }
        string ControlName { get; }
        int TimeOut { get; }

        #endregion
    }
}
