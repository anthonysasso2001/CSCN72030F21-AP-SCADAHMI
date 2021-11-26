using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class InteriorTemp : HardwareIO
    {
        private double maxTemp;
        private double minTemp;
        public InteriorTemp(string inputFileName) : base(inputFileName, true)
        {
            maxTemp = 30;
            minTemp = 16;
        }

        public override bool display(int inputTime)
        {
            int lineTotal = File.ReadAllLines(this.getFileName()).Count();
            int countLine = 1;

            for (int i = 1; i <= inputTime; i++)
            {
                if (fileGet(i - 1) == null) //check if the line is empty
                    break;

                double currentTemp = Double.Parse(fileGet(i - 1));

                if (!checkTempBounds(currentTemp))
                {
                    this.warningMessage(currentTemp);
                    Thread.Sleep(3000); //Sleep for 3 sec
                }
                Console.Write("The current interior temperature is: " + currentTemp+" Celsius degrees");
                countLine++;

                if (countLine == lineTotal)     //Stop if reached the last line
                    break;

                Thread.Sleep(1000); //Sleep for 1 sec
            }
            return true;
        }
        public override bool modify(string inputValue)
        {
            int arraySize = 50;
            double newTemp = Double.Parse(inputValue);
            int lineTotal = File.ReadAllLines(this.getFileName()).Count();
            double currentTemp = Double.Parse(fileGet(lineTotal)); //read the last line to get the current value
            double tempDiff = Math.Abs(currentTemp - newTemp);
            String newTempList="";
            
            for (int i = 0; i < currentTemp; i++)
            {
                if (currentTemp < newTemp)
                {
                    newTempList += (Convert.ToString(currentTemp + i)+"\n"); //increasing
                }
                else
                {
                    newTempList += (Convert.ToString(currentTemp - i) + "\n");   //decreasing
                }
            }
            this.fileUpdate(newTempList);
            Console.WriteLine("Interior Temperature is modified successfully");
            return true;
        }
        private bool checkTempBounds(double currentTemp)
        {
            if (currentTemp <= minTemp) //if temp is lower than 16 degree
                return false;
            else if (currentTemp >= maxTemp)    //if temp is higher than 30 degree
                return false;
            else
                return true;
        }

        private void warningMessage(double currentTemp)
        {
            if (checkTempBounds(currentTemp))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WARNING!!\nBetween 16-30 Celsius degrees is better for your health!");
            }


        }
    }
}
