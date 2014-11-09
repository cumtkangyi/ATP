using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATP.Core
{
    public interface IUIAutomationRunner : IDisposable
    {
        // Methods
        object Execute(IUIAutomationRunner action);
    }

    public class UIAutomationRunner : IUIAutomationRunner
    {
        #region IAction Members

        public object Execute(IUIAutomationRunner action)
        {
            action = new UIAutomationRunner();
            return null;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose();
        }

        #endregion
    }
}
