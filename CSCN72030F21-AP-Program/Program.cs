using System;
using CSCN72030F21_AP_Classes;

namespace CSCN72030F21_AP_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataFile = "..\\Data\\";   //"macro for file path
            HardwareIO test = new HardwareIO((dataFile+"test.txt"), true);
            test.fileUpdate("testone\ntesttwo\ntestThree\n");

            Console.WriteLine("Line 2 is: {0}",test.fileGet(4));
        }
    }
}
