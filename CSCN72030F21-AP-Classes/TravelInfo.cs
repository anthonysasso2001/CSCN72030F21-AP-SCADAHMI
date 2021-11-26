using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
            for (int i = 1; i < inputTime + 1; i++)
            {
                char delimiter = ',';

                string readLine = fileGet(i);

                string[] splitLine = readLine.Split(delimiter);

                this.distance = double.Parse(splitLine[0]);
                this.time = double.Parse(splitLine[1]);

                Console.WriteLine("Distance until arrival: " + this.distance + "KM");
                Console.WriteLine("Time until arrival: " + this.time + "H\n");

                if (this.distance <= 500)
                {
                    DestinationClose();
                }

            }

            return true;
        }
        public override bool modify(string inputValue)
        {
            return true;
        }

        public void DestinationClose()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("We will soon be arriving at our destination. Please prepare for landing.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
