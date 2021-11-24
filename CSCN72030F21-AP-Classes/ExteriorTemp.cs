using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class ExteriorTemp : HardwareIO
    {
        public ExteriorTemp(string inputFileName) : base(inputFileName, false)
        {
            
        }
         
        public override bool display(int inputTime)
        {
            int extTemp = Int32.Parse(fileGet(0));
            Console.Write("The current exterior temperature is:");
            if(extTemp < (-40))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(fileGet(0) + "\n");
            }
            else if(extTemp >50)
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
            return true;
        }
    }
}
