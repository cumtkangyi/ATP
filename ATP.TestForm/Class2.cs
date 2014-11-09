using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation.Provider;
using System.Windows.Automation.Text;
using System.Windows.Automation;

namespace UIAutomationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nBegin WinForm UIAutomation test run\n");
                // launch Form1 application
                // get refernce to main Form control
                // get references to user controls
                // manipulate application
                // check resulting state and determine pass/fail

                Console.WriteLine("\nBegin WinForm UIAutomation test run\n");
                Console.WriteLine("Launching WinFormTest application");
                //启动被测试的程序
                Process p = Process.Start(@"E:\Project\WinFormTest\WinFormTest\bin\Debug\WinFormTest.exe");

                //自动化根元素
                AutomationElement aeDeskTop = AutomationElement.RootElement;

                Thread.Sleep(2000);
                AutomationElement aeForm = AutomationElement.FromHandle(p.MainWindowHandle);
                //获得对主窗体对象的引用，该对象实际上就是 Form1 应用程序(方法一)
                //if (null == aeForm)
                //{
                //    Console.WriteLine("Can not find the WinFormTest from.");
                //}

                //获得对主窗体对象的引用，该对象实际上就是 Form1 应用程序(方法二)
                int numWaits = 0;
                do
                {
                    Console.WriteLine("Looking for WinFormTest……");
                    //查找第一个自动化元素
                    aeForm = aeDeskTop.FindFirst(TreeScope.Children, new PropertyCondition(
                        AutomationElement.NameProperty, "Form1"));
                    ++numWaits;
                    Thread.Sleep(100);
                } while (null == aeForm && numWaits < 50);
                if (null == aeForm)
                    throw new NullReferenceException("Failed to find WinFormTest.");
                else
                    Console.WriteLine("Found it!");

                Console.WriteLine("Finding all user controls");
                //找到第一次出现的Button控件
                AutomationElement aeButton = aeForm.FindFirst(TreeScope.Children,
                  new PropertyCondition(AutomationElement.NameProperty, "button1"));

                //找到所有的TextBox控件
                AutomationElementCollection aeAllTextBoxes = aeForm.FindAll(TreeScope.Children,
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                // 控件初始化的顺序是先初始化后添加到控件
                // this.Controls.Add(this.textBox3);                  
                // this.Controls.Add(this.textBox2);
                // this.Controls.Add(this.textBox1);

                AutomationElement aeTextBox1 = aeAllTextBoxes[2];
                AutomationElement aeTextBox2 = aeAllTextBoxes[1];
                AutomationElement aeTextBox3 = aeAllTextBoxes[0];

                Console.WriteLine("Settiing input to '30'");
                //通过ValuePattern设置TextBox1的值
                ValuePattern vpTextBox1 = (ValuePattern)aeTextBox1.GetCurrentPattern(ValuePattern.Pattern);
                vpTextBox1.SetValue("30");
                Console.WriteLine("Settiing input to '50'");
                //通过ValuePattern设置TextBox2的值
                ValuePattern vpTextBox2 = (ValuePattern)aeTextBox2.GetCurrentPattern(ValuePattern.Pattern);
                vpTextBox2.SetValue("50");
                Thread.Sleep(1500);
                Console.WriteLine("Clickinig on button1 Button.");
                //通过InvokePattern模拟点击按钮
                InvokePattern ipClickButton1 = (InvokePattern)aeButton.GetCurrentPattern(InvokePattern.Pattern);
                ipClickButton1.Invoke();
                Thread.Sleep(1500);

                //验证计算的结果与预期的结果是否相符合
                Console.WriteLine("Checking textBox3 for '80'");
                TextPattern tpTextBox3 = (TextPattern)aeTextBox3.GetCurrentPattern(TextPattern.Pattern);
                string result = tpTextBox3.DocumentRange.GetText(-1);//获取textbox3中的值
                //获取textbox3中的值
                //string result = (string)aeTextBox2.GetCurrentPropertyValue(ValuePattern.ValueProperty);
                if ("80" == result)
                {
                    Console.WriteLine("Found it.");
                    Console.WriteLine("TTest scenario: *PASS*");
                }
                else
                {
                    Console.WriteLine("Did not find it.");
                    Console.WriteLine("Test scenario: *FAIL*");
                }

                Console.WriteLine("Close application in 5 seconds.");
                Thread.Sleep(5000);
                //实现关闭被测试程序
                WindowPattern wpCloseForm = (WindowPattern)aeForm.GetCurrentPattern(WindowPattern.Pattern);
                wpCloseForm.Close();

                Console.WriteLine("\nEnd test run\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
        }
    }
}