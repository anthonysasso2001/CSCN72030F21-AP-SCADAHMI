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
            int currentLine = 1;
            int termination = 1;
            int i = 1;
            while (termination <= inputTime)
            {

                if (this.fileGet(currentLine) == "LINE_ERROR Sequence contains no elements") //if the line is empty and the input time is longer, loop back
                {
                    currentLine = 1;
                    continue;
                }
                int currentLevel = Int32.Parse(fileGet(currentLine));

                if (!liquidIsLow(currentLevel))
                {
                    this.warningMessage(currentLevel);
                    Thread.Sleep(3000); //Sleep for 3 sec
                }
                Console.WriteLine("The current liquid level is:" + currentLevel + "%");
                currentLine++;
                termination++;

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
