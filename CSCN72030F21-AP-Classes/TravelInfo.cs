//Project III - Software Development
//Conestoga College
//Sep. 2021 - Dec. 2021
//Contributers:
//              Thi Huong Tra Le (Rachel)
//              Anthony Sasso
//              Navdeep Mangat
//              Eazaz Jakda
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Navdeep's module

namespace CSCN72030F21_AP_Classes
{
    public class TravelInfo : HardwareIO
    {

        private double distance;
        private double time;

        public TravelInfo(string inputFileName) : base(inputFileName, false)
        {
            this.distance = 0;
            this.time = 0;
        }

        public override bool display(int inputTime)
        {
            int lineCount = File.ReadAllLines(this.getFileName()).Count();

            int count = 0;
            int countFactor = 1;

            for (int i = 1; i < inputTime + 1; i++)
            {
                char delimiter = ',';

                string readLine = fileGet(i);

                string[] splitLine = readLine.Split(delimiter);

                this.distance = double.Parse(splitLine[0]);
                this.time = double.Parse(splitLine[1]);


                if (this.distance <= 500)
                {
                    DestinationClose();
                }
                else
                {
                    Console.WriteLine("Distance until arrival: {0}KM", this.distance);
                    Console.WriteLine("Time until arrival: {0}H", this.time);
                }

                Console.WriteLine("");

                count++;

                if(count == lineCount * countFactor)
                {
                    i = 0;
                    countFactor++;
                }
                if(count == inputTime)
                {
                    break;
                }

                System.Threading.Thread.Sleep(1000);
            }

            return true;
        }
        public override bool modify(string inputValue)
        {
            return true;
        }

        public void DestinationClose()
        {
            Console.Write("Distance until arrival: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}KM", this.distance);
            Console.WriteLine("We will soon be arriving at our destination. Please prepare for landing.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
