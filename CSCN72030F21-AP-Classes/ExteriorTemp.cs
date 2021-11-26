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
            int countLine = 1;

            for (int i = 1; i <= inputTime; i++)
            {
                if (fileGet(i - 1) == null) //check if the line is empty
                    break;

                double currentTemp = Double.Parse(fileGet(i-1));
                
                if (!checkTempBounds(currentTemp))
                {
                    this.warningMessage(currentTemp);
                    Thread.Sleep(3000); //Sleep for 3 sec
                }
                Console.Write("The current exterior temperature is:" + currentTemp+" Celsius degrees");
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
