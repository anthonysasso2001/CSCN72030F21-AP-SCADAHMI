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

//Eazaz Jakda

namespace CSCN72030F21_AP_Classes
{
    public class AirSpeed : HardwareIO
    {
        private int currentSpeed;
        public AirSpeed(string inputFileName) : base(inputFileName, true)
        {
            this.currentSpeed = 0;
        }

        public int getSpeed()
        {
            return this.currentSpeed;
        }

        public void setSpeed(int speed)
        {
            this.currentSpeed = speed;
        }

        public override bool display(int inputTime)
        {
            int lineCount = File.ReadAllLines(this.getFileName()).Count();

            int count = 0;

            for(int i = 1; i < inputTime + 1; i++)
            {
                string loadedString = fileGet(i);

                currentSpeed = Convert.ToInt32(loadedString);
                int speedCheck = speedRange(currentSpeed);

                if(speedCheck == 0)
                {
                    Console.Write("The Speed is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentSpeed);
                    Console.WriteLine("\t\tThe Speed is below the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    
                }
                else if(speedCheck == 2)
                {
                    Console.Write("The Speed is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentSpeed);
                    Console.WriteLine("\t\tThe Speed is above the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write("The Speed is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentSpeed);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                System.Threading.Thread.Sleep(1000);
                count++;
                if (count == lineCount)
                {
                    i = 0;
                }
                if (count == inputTime)
                {
                    break;
                }

            }
            return true;
        }

        private int speedRange(int speed)
        {
            int status;

            if (speed < 300)
            {
                status = 0;
            }
            else if (speed >= 100 && speed <= 900)
            {
                status = 1;
            }
            else
            {
                status = 2;
            }

            return status;

        }

        public override bool modify(string inputValue)
        {
            int speed = Convert.ToInt32(inputValue);
            int speedStart = 200;
            int speedDiff = speed - speedStart;

            int interval = speedDiff / 10;

            string newValues = "";

            for(int i = 1; i < 11; i++)
            {
                int newSpeed = speedStart + (interval * i);

                newValues += Convert.ToString(newSpeed) + '\n';
            }

            bool updateStatus = this.fileUpdate(newValues);

            return updateStatus;
        }
    }
}
