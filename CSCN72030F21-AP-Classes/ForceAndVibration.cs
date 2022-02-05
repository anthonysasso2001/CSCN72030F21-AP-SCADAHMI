//Project III - Software Development
//Conestoga College
//Sep. 2021 - Dec. 2021
//Contributers:
//              Thi Huong Tra Le(Rachel)
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
    public class ForceAndVibration : HardwareIO
    {
        private int currentForce;
        private int currentVibration;
        public ForceAndVibration(string inputFileName) : base(inputFileName, false)
        {
            this.currentForce = 0;
            this.currentVibration = 0;
        }

        public int getCurrentForce()
        {
            return this.currentForce;
        }

        public int getCurrentVibration()
        {
            return this.currentVibration;
        }

        private string[] LoadValues(int position)
        {
            char delimiter = ',';

            string loadedString = fileGet(position); // reads one line from file

            string[] loadedValues = loadedString.Split(delimiter); // split it into force and vibration

            return loadedValues;

        }

        public override bool display(int inputTime)
        {
            
            int lineCount = File.ReadAllLines(this.getFileName()).Count();

            int count = 0;

            int countFactor = 1;

            for (int i = 1; i < inputTime + 1; i++)
            {
                //Console.Clear();

                string[] loadedValues = LoadValues(i);

                currentForce = Convert.ToInt32(loadedValues[0]);
                int forceCheck = ForceRange(currentForce);      //returns 0, 1, 2


                currentVibration = Convert.ToInt32(loadedValues[1]);
                int vibrationCheck = VibrationRange(currentVibration);



                if (forceCheck == 2)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentForce);
                    Console.WriteLine("\t\tThe Force is above the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentVibration);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (forceCheck == 0)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentForce);
                    Console.WriteLine("\t\tThe Force is under the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentVibration);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (vibrationCheck == 2)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentForce);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentVibration);
                    Console.WriteLine("\tThe Vibration is above the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (vibrationCheck == 0)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentForce);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentVibration);
                    Console.WriteLine("\tThe Vibration is under the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (forceCheck == 2 && vibrationCheck == 2)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentForce);
                    Console.WriteLine("\t\tThe Force is above the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentVibration);
                    Console.WriteLine("\tThe Vibration is above the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (forceCheck == 2 && vibrationCheck == 0)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentForce);
                    Console.WriteLine("\t\tThe Force is above the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentVibration);
                    Console.WriteLine("\tThe Vibration is under the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (forceCheck == 0 && vibrationCheck == 2)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentForce);
                    Console.WriteLine("\t\tThe Force is under the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentVibration);
                    Console.WriteLine("\tThe Vibration is above the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (forceCheck == 0 && vibrationCheck == 0)
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentForce);
                    Console.WriteLine("\t\tThe Force is under the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", currentVibration);
                    Console.WriteLine("\tThe Vibration is under the optimal range.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.Write("The Force is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentForce);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("The Vibration is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentVibration);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }


                System.Threading.Thread.Sleep(1000);
                count++;

                int newCount = lineCount * countFactor;
                if (count == lineCount)
                {
                    i = 0;
                    countFactor++;
                }
                if (count == inputTime)
                {
                    break;
                }

                //Console.Clear();
            }
            return true;
        }

        private int ForceRange(int force)
        {
            int status;

            if(force <5)
            {
                status = 0;
            }
            else if(force >= 5 && force <= 10)
            {
                status = 1;
            }
            else
            {
                status = 2;
            }

            return status;

        }

        private int VibrationRange(int Vibration)
        {
            int status;

            if (Vibration < 5)
            {
                status = 0;
            }
            else if (Vibration >= 5 && Vibration <= 10)
            {
                status = 1;
            }
            else
            {
                status = 2;
            }

            return status;

        }

        private void forceWarning(bool status)
        {
            
            if(status == true)
            {
                Console.WriteLine("The Force value is under the acceptable range.");
                               
            }

            if(status == false)
            {
                Console.WriteLine("The Force value is above the acceptable range.");
                
            }
            
        }

        private void vibrationWarning(int status)
        {
            if (status == 0)
            {
                Console.WriteLine("The Vibration value is under the acceptable range.");
                return;
            }
            else if (status == 1)
            {
                return;
            }
            else
            {
                Console.WriteLine("The Vibration value is above the acceptable range.");
                return;
            }
        }

        private bool intToBool(int status)
        {
            if(status == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }







        public override bool modify(string inputValue)          //Not going to called because its a display only module
        {
            return true;
        }


    }
}
