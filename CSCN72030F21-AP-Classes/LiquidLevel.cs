using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class LiquidLevel : HardwareIO
    {
        public LiquidLevel(string inputFileName) : base(inputFileName, false)
        {

        }

        public override bool display(int inputTime)
        {
            int liquidPercentage = Int32.Parse(fileGet(0));
            Console.Write("The current liquid level is:");
            if (liquidPercentage > 25)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(fileGet(0) + "\n");
            }
            else if (liquidPercentage == 25)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(fileGet(0) + "\n");
                Console.WriteLine("Warning: Liquid Level is low");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(fileGet(0) + "\n");
            }
            return true;
        }
        public override bool modify(string inputValue)
        {
            return true;
        }
    }
}
