using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class InteriorTemp : HardwareIO
    {
        public InteriorTemp(string inputFileName) : base(inputFileName, true)
        {

        }

        public override bool display(int inputTime)
        {
                int interiorTemp = Int32.Parse(fileGet(0));
                Console.Write("The current exterior temperature is:");
            if (interiorTemp < (16))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(fileGet(0) + "\n");
            }
            else if (interiorTemp > 30)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(fileGet(0) + "\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(fileGet(0) + "\n");
            }
            return true;
        }
        public override bool modify(string inputValue)
        {
            this.fileUpdate(inputValue);
            Console.WriteLine("Interior Temperature is modified successfully");
            return true;
        }
    }
}
