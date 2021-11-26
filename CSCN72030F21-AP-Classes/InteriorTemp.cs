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
                    Thread.Sleep(1000); //Sleep for 3 sec
                }
                Console.WriteLine("The current interior temperature is:" + currentTemp + " Celsius degrees");
                currentLine++;
                termination++;

                Thread.Sleep(1000); //Sleep for 1 sec

            }
            return true;
        }
        public override bool modify(string inputValue)
        {
            double newTemp = Double.Parse(inputValue);
            int lineTotal = File.ReadAllLines(this.getFileName()).Count();
            string outputData = this.fileGet(lineTotal);
            double currentTemp = Double.Parse(outputData); //read the last line to get the current value
            double tempDiff = Math.Abs(currentTemp - newTemp);
            String newTempList="";
            
            for (int i = 0; i <= tempDiff; i++)
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
            if (!checkTempBounds(currentTemp))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WARNING!!\nBetween 16-30 Celsius degrees is better for your health!");
                Console.ForegroundColor = ConsoleColor.White;
            }



        }
    }
}
