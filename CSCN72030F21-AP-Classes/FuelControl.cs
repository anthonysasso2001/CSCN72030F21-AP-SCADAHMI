using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Navdeep Mangat's module 

namespace CSCN72030F21_AP_Classes
{
    public class FuelControl : HardwareIO
    {

        private double fuelReading;

        public FuelControl(string inputFileName) : base(inputFileName, true)
        {
            this.fuelReading = 0;
        }

        public override bool display(int inputTime)
        {
            int lineCount = File.ReadAllLines(this.getFileName()).Count();

            int count = 0;
            int countFactor = 1;

            for (int i = 1; i < inputTime + 1; i++)
            {

                string readLine = fileGet(i);

                this.fuelReading = double.Parse(readLine);

                if (this.fuelReading <= 20)
                {
                    fuelWarning();
                }
                else
                {
                    Console.WriteLine("The fuel reading is currently: {0}%", this.fuelReading);
                }

                Console.WriteLine("");

                count++;

                if (count == lineCount * countFactor)
                {
                    i = 0;
                    countFactor++;
                }
                if (count == inputTime)
                {
                    break;
                }

                System.Threading.Thread.Sleep(1000);
            }

            return true;

        }
        public override bool modify(string inputValue)
        {
            double fuelModify = Convert.ToDouble(inputValue);

            double fuelStart = 70;
            double fuelDiff = fuelStart - fuelModify;

            string newFuelReadings = "";

            for(int i = 1; i < fuelModify + 1; i++)
            {
                double newFuel = fuelStart - i;
                newFuelReadings += Convert.ToString(newFuel) + "\n";
            }

            bool newStatus = this.fileUpdate(newFuelReadings);

            return true;
        }

        public void fuelWarning()
        {
            Console.Write("The fuel reading is currently: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}%", this.fuelReading);
            Console.WriteLine("The fuel levels are critically low!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
