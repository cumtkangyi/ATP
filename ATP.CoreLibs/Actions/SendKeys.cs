using System;
using ATP.Core;
using System.Windows.Automation;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace ATP.CoreLibs.Actions
{
    class SendKeys:UIWindowAndElement,IUIAutomationRunner
    {
        public const string Alt = "%";
        public const string ContextMenu = "+{F10}";
        public const string Ctrl = "^";
        public const string Shift = "+";
        public const string Enter = "{Enter}";
        public const string Delete = "{Del}";

        // Properties
        public string[] Keys{ get; set; }

        public int Timeout { get; set; }


        #region IUIAutomationRunner Members

        public object Execute(IUIAutomationRunner action)
        {
            AutomationElement element = UIAutomationHelper.FindWindow(this, this.Timeout);
            //AssertionHelper.AssertWindowElementNotNull(context, element, this);
            if (base.WindowName != null)
            {
                //action.Runner.UIAutomation().AssertWindowStateByName(base.WindowName, WindowCurrentState.ReadyForInput, this.Timeout);
            }
            try
            {
                element.SetFocus();
            }
            catch (Exception exception)
            {
               // action.Logger.LogComment(string.Format("Could not set focus on window. {0}", exception.ToString()));
            }
            string keys = "";
            foreach (string str2 in this.Keys)
            {
                keys = keys + str2;
            }
            Thread.Sleep(200);
            if ((this.ContainsUnescapedKey(keys, '^') || this.ContainsUnescapedKey(keys, '%')) || this.ContainsUnescapedKey(keys, '+'))
            {
                keys = keys.ToLower();
            }
            System.Windows.Forms.SendKeys.SendWait(keys);
            Thread.Sleep(0x3e8);

            return null;
        }

        

        // Methods
        private bool ContainsUnescapedKey(string keys, char key)
        {
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == key)
                {
                    if ((i == 0) || (i == (keys.Length - 1)))
                    {
                        return true;
                    }
                    if ((keys[i - 1] != '{') || (keys[i + 1] != '}'))
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        private string KeysToString(string[] keys)
        {
            StringBuilder builder = new StringBuilder();
            if (keys != null)
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    string str = keys[i];
                    if (str == null)
                    {
                        goto Label_0088;
                    }
                    if (!(str == "%"))
                    {
                        if (str == "+")
                        {
                            goto Label_005E;
                        }
                        if (str == "^")
                        {
                            goto Label_006C;
                        }
                        if (str == "+{F10}")
                        {
                            goto Label_007A;
                        }
                        goto Label_0088;
                    }
                    builder.Append("Alt");
                    goto Label_0092;
                Label_005E:
                    builder.Append("Shift");
                    goto Label_0092;
                Label_006C:
                    builder.Append("Ctrl");
                    goto Label_0092;
                Label_007A:
                    builder.Append("Open Context Menu");
                    goto Label_0092;
                Label_0088:
                    builder.Append(keys[i]);
                Label_0092:
                    if (i < (keys.Length - 1))
                    {
                        builder.Append("+");
                    }
                }
            }
            return builder.ToString();
        }


        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Public Method

        public override string ToString()
        {
            return string.Format("Action name is '{0}', windowName is '{1}', processId is '{2}', element name is '{3}', the control type is '{4}', time out is '{5}'",
                this.GetType().Name, this.WindowName, this.ProcessId, this.ControlName, ControlType.Button, this.TimeOut);
        }
        #endregion
    }
}
