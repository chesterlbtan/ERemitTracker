using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Remit_Tracker;

namespace ERT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ERT is running");
            System.Threading.Thread.Sleep(100);

            switch (args[0].ToUpper())
            {
                case "AUTORUN":
                    Console.WriteLine("autorun is chosen.");
                    double php = 0, idr = 0;
                    if (Tracker.IsSiteAvailable(ref php, ref idr))
                    {
                        Tracker.LogChanges(php, idr);
                        Console.WriteLine("1 MYR = " + php.ToString("F2") + " PHP");
                        Console.WriteLine("1 MYR = " + idr.ToString("F2") + " IDR");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
