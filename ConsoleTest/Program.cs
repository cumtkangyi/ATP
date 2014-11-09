using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using ATP.Core;
using ATP.CoreLibs;
using System.Threading;
using System.Windows.Automation;


namespace ConsoleTest
{
    class Program
    {
        static int processId=0;

        static Tester tester = new Tester();

        static void Main(string[] args)
        {
            //Console.WriteLine("Starting...");
            //List<int> list = new List<int>();

            //string str = "";
            //Process[] processes;
            ////Get the list of current active processes.
            //processes = System.Diagnostics.Process.GetProcesses();
            ////Grab some basic information for each process.
            //Process process1;
            //for (int i = 0; i < processes.Length - 1; i++)
            //{
            //    process1 = processes[i];
            //    str = str + Convert.ToString(process1.Id) + " : " +
            //    process1.ProcessName + "\r\n";
            //    list.Add(process1.Id);
            //}


            //Process process = Process.Start(@"F:\CSharpDotNet\AutomationTest\ATP\ATP.TestForm\bin\Debug\ATP.TestForm.exe");
            ////Process process = Process.Start(@"E:\WorkBook\WpfApplication1\WpfApplication1\bin\Debug\WpfApplication1.exe");
            
            //processId = process.Id;

            //Console.WriteLine("The current App processId is:" + processId);

            //try
            //{
            //    Process myprocess = new Process();
            //    ProcessStartInfo startInfo = new ProcessStartInfo(@"F:\CSharpDotNet\AutomationTest\ATP\ConsoleApplication1\bin\Debug\ConsoleApplication1.exe", processId.ToString());
            //    startInfo.WindowStyle = ProcessWindowStyle.Normal;
            //    myprocess.StartInfo = startInfo;
            //    myprocess.StartInfo.UseShellExecute = true;
            //    myprocess.Start();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Source + ex.Message + ex.StackTrace + ex.TargetSite);
            //}
            //Thread.Sleep(3000);
            //tester.SetTextBoxTextById(processId, "textBox1", "Test Text");
            //Thread.Sleep(3000);

            //tester.UIAutomation().ClickButtonById(processId, "button2");
            //Thread.Sleep(1000);
            //tester.UIAutomation().ClickButtonByName(processId, "OK");
            //Thread.Sleep(1000);
            ////tester.().ClickButtonById(processId, "button2");
            ////tester.FindWindowsControl(processId);

            //Thread.Sleep(3000);

            //tester.NativeMethods().ClickLeftMouseById(processId, "button1");
            //foreach (int pid in list)
            //{
            //    Console.WriteLine(pid);
            //    if (processId == pid)
            //    {
            //        break;
            //    }
            //}

            //tester.UIAutomation().ClickButtonById(1340, "PART_SegmentedButton", 3000);
            //Thread.Sleep(3000);
            //tester.UIAutomation().ClickButtonById(1340, "saveAll", 3000);

            //Class1.STR = "Kaden";
            //Class1.Show();

            Console.WriteLine("End");
          }   
    }
}
