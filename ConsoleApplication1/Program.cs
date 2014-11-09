using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Diagnostics;
using FTP.Core;
using FTP.CoreLibs;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var p1 = new { Id = 1, Name = "YJingLee", Age = 22 };//属性也不需要申明
            //var p2 = new { Id = 2, Name = "XieQing", Age = 25 };
            //Console.WriteLine(p1.ToString()+"\n"+p2.ToString());

            int[] iarr1 = new int[] { 1, 2, 3, 4 };
            int[] iarr2 =iarr1;

            iarr2[3] = 100;
            Console.WriteLine(iarr1[3]);
            Console.WriteLine(iarr2[3]);
            Console.ReadLine();
        }
    }
}
