using System;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;

namespace UIATest
{
    class Program
    {
        static void Main(string[] args)
        {
            Process process = Process.Start(@"F:\CSharpDotNet\AutomationTest\ATP\WpfApp\bin\Debug\WpfApp.exe");
            int processId = process.Id;

            AutomationElement element = FindElementById(processId, "textBox1");
            SendKeys sendkeys = new SendKeys();
            sendkeys.Sendkeys(element, "Sending keys to input data");
            Console.WriteLine(sendkeys.ToString());
            sendkeys.Sendkeys(element, sendkeys.ContextMenu);
            Console.WriteLine(sendkeys.ToString());
            sendkeys.Sendkeys(element, new string[]{"{Enter}","{Delete}"});
            Console.WriteLine(sendkeys.ToString());
            Console.WriteLine("Test finised.");   
        }

        /// <summary>
        /// Get the automation elemention of current form.
        /// </summary>
        /// <param name="processId">Process Id</param>
        /// <returns>Target element</returns>
        public static AutomationElement FindWindowByProcessId(int processId)
        {
            AutomationElement targetWindow = null;
            int count = 0;
            try
            {
                Process p = Process.GetProcessById(processId);
                targetWindow = AutomationElement.FromHandle(p.MainWindowHandle);
                return targetWindow;
            }
            catch (Exception ex)
            {
                count++;
                StringBuilder sb = new StringBuilder();
                string message = sb.AppendLine(string.Format("Target window is not existing.try #{0}", count)).ToString();
                if (count > 5)
                {
                    throw new InvalidProgramException(message, ex);
                }
                else
                {
                    return FindWindowByProcessId(processId);
                }
            }
        }

        /// <summary>
        /// Get the automation element by automation Id.
        /// </summary>
        /// <param name="windowName">Window name</param>
        /// <param name="automationId">Control automation Id</param>
        /// <returns>Automatin element searched by automation Id</returns>
        public static AutomationElement FindElementById(int processId, string automationId)
        {
            AutomationElement aeForm = FindWindowByProcessId(processId);
            AutomationElement tarFindElement = aeForm.FindFirst(TreeScope.Descendants,
            new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
            return tarFindElement;
        }
    }
}