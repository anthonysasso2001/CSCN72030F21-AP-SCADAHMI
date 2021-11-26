using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class LiquidLevel : HardwareIO
    {
        private int lowLiquidLevel;
        public LiquidLevel(string inputFileName) : base(inputFileName, false)
        {
            lowLiquidLevel = 25 ;
        }

        public override bool display(int inputTime)
        {
            int lineTotal = File.ReadAllLines(this.getFileName()).Count();
            int countLine = 1;

            for (int i = 1; i <= inputTime; i++)
            {
                if (fileGet(i - 1) == null) //check if the line is empty
                    break;

                int currentLiquidLevel = Int32.Parse(fileGet(i - 1));

                if (!liquidIsLow(currentLiquidLevel))
                {
                    this.warningMessage(currentLiquidLevel);
                    Thread.Sleep(3000); //Sleep for 3 sec
                }
                Console.Write("The current liquid level is: " + currentLiquidLevel + "%");
                countLine++;

                if (countLine == lineTotal)     //Stop if reached the last line
                    break;

                Thread.Sleep(1000); //Sleep for 1 sec
            }
            return true;
        }
        public override bool modify(string inputValue)
        {
            return true;
        }
        private bool liquidIsLow(int currentLiquidLevel)
        {
            if (currentLiquidLevel <= lowLiquidLevel) //if temp is lower than -26%
                return false;
            return true;
        }

        private void warningMessage(int currentLiquidLevel)
        {
            if (liquidIsLow(currentLiquidLevel))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WARNING!!\nLiquid level is low!");
            }


        }
    }
}
