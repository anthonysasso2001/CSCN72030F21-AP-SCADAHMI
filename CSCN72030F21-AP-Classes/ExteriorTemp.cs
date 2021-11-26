using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace CSCN72030F21_AP_Classes
{
    public class ExteriorTemp : HardwareIO
    {
        private double maxTemp;
        private double minTemp;
        public ExteriorTemp(string inputFileName) : base(inputFileName, false)
        {
            maxTemp = 50;
            minTemp = -40; 
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
                double currentTemp = Double.Parse(fileGet(currentLine));

                if (!checkTempBounds(currentTemp))
                {
                    this.warningMessage(currentTemp);
                    Thread.Sleep(3000); //Sleep for 3 sec
                }
                Console.WriteLine("The current exterior temperature is:" + currentTemp + " Celsius degrees");
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
        private bool checkTempBounds(double currentTemp)
        {
            if (currentTemp <= minTemp) //if temp is lower than -40 degree
                return false;
            else if (currentTemp >= maxTemp)    //if temp is higher than 50 degree
                return false;
            else
                return true;
        }

        private void warningMessage(double currentTemp)
        {
            if (checkTempBounds(currentTemp))
            { 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WARNING!!\nExterior temperature is extreme!");          
            }
         

        }

    }
}
