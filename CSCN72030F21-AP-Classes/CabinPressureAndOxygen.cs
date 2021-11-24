using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class CabinPressureAndOxygen : HardwareIO
    {
        private double minPressureBound;
        private double maxPressureBound;
        private int minOLevelBound;
        private int maxOLevelBound;

        public CabinPressureAndOxygen(string inputFileName) : base(inputFileName, false)
        {
            this.minPressureBound = 5;  //5psi danger, 9psi warning, 11-12 psi normal, 14 psi warning, 17 psi danger
            this.maxPressureBound = 17;
            this.minOLevelBound = 14;   //6% = death, 14% = danger, 16% warning, 19%  normal, 21% warning, 23% = danger
            this.maxOLevelBound = 23;
        }

        public override bool display(int inputTime)
        {
            double[] displayData = this.getAndFormatData(inputTime);
            bool displayState = true;
            for (int i = 1; i < (inputTime+1); i+=2)
            {
                if (!this.checkPressureBounds(displayData[i]))
                {
                    if(false == this.pressureResponseWarning(displayData[i]))
                    {
                        double pressureWarningAmount = this.pressureWarningDiff(displayData[i]);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("WARNING");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("plane pressure: {0} psi, Oxygen Level: {1}%\n Pressure is {2} psi out of bounds", displayData[i], displayData[i + 1], pressureWarningAmount);
                        displayState = false;
                    }
                }
                else if (!this.checkOxygenBounds(Convert.ToInt32(displayData[i+1])))
                {
                    if(false == this.oxygenLevelResponseWarning(Convert.ToInt32(displayData[i + 1])))
                    {
                        double oxygenWarningAmount = this.oxygenWarningDiff(Convert.ToInt32(displayData[i]));
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("WARNING");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("plane pressure: {0} psi, Oxygen Level: {1}%\n Oxygen is {2}% out of bounds", displayData[i], displayData[i + 1], oxygenWarningAmount);
                        displayState = false;
                    }
                }
                else
                {
                    Console.WriteLine("plane Pressure: {0}, Oxygen Level: {1}\n", displayData[i], displayData[i + 1]);
                }
            }
            return displayState;    //true for no errors, false is a warning was called (errors interrupt and exit so not handled here
        }

        public override bool modify(string inputValue)
        {
            throw new ArgumentException();  //should not access this throw exception    
        }

        public class PressureTooLowException : System.Exception
        {
            public PressureTooLowException(double inputPressure)
              : base(String.Format("plane pressure is {0} psi under acceptable limit", inputPressure)) { }
        }

        public class PressureTooHighException : System.Exception
        {
            public PressureTooHighException(double inputPressure)
              : base(String.Format("plane pressure is {0} psi over acceptable limit", inputPressure)) { }
        }

        public class OxygenTooLowException : System.Exception
        {
            public OxygenTooLowException(int inputOxygen)
              : base(String.Format("plane oxygen is {0}% under acceptable limit", inputOxygen)) { }
        }

        public class OxygenTooHighException : System.Exception
        {
            public OxygenTooHighException(int inputOxygen)
              : base(String.Format("plane pressure is {0}% over acceptable limit", inputOxygen)) { }
        }

        private double pressureWarningDiff(double inputPressure)    //5psi danger, 9psi warning, 11-12 psi normal, 14 psi warning, 17 psi danger
        {
            double outputDifferential = 0;

            if (5 >= inputPressure) //if pressure is under 5
            {
                throw new PressureTooLowException(inputPressure);
            }
            else if ((5 < inputPressure) && (9 >= inputPressure))  //if pressure is between 5-9
            {
                outputDifferential = 9 - inputPressure;
                
            }
            else if ((9 < inputPressure) && (14 > inputPressure)) //if pressure is in normal bounds
            {
               outputDifferential = 0;   //incase it passes through a valid pressure...
            }
            else if ((17 > inputPressure) && (14 <= inputPressure))    //if pressure is between 14-17
            {
                outputDifferential = 14 - inputPressure;
            }
            else if (17 <= inputPressure)
            {
                throw new PressureTooHighException(inputPressure);
            }
            return outputDifferential;
        }

        private int oxygenWarningDiff(int inputOxygen)    //6% = death, 14% = danger, 16% warning, 19%  normal, 21% warning, 23% = danger
        {
            int outputDifferential = 0;

            if (14 >= inputOxygen) //if pressure is under 14%
            {
                throw new OxygenTooLowException(inputOxygen);
            }
            else if ((14 < inputOxygen) && (17 >= inputOxygen))  //if oxygen level is between 14-17%
            {
                outputDifferential = 17 - inputOxygen;
            }
            else if ((17 < inputOxygen) && (20 > inputOxygen)) //if oxygen levels are in normal bounds
            {
                outputDifferential = 0;   //incase it passes through a valid O level...
            }
            else if ((22 > inputOxygen) && (20 <= inputOxygen))    //if oxygen is between 22%-20%
            {
                outputDifferential = 14 - inputOxygen;
            }
            else if (22 <= inputOxygen) //if oxygen is above 22%
            {
                throw new OxygenTooHighException(inputOxygen);
            }
            return outputDifferential;
        }

        private bool checkPressureBounds(double pressureValue)
        {
            if (9 >= pressureValue) //if pressure is under 9
            {
                return false;
            }
            else if (14 <= pressureValue)   //if pressure is over 14
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool checkOxygenBounds(int oxygenValue)
        {
            if (17 >= oxygenValue) //if oxygen is under 17%
            {
                return false;
            }
            else if (20 <= oxygenValue)   //if oxygen is over 20%
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private double[] getAndFormatData(int inputTime)
        {
            double[] outputDouble = new double[] { 0 };
            return outputDouble;
        }

        private bool pressureResponseWarning(double inputPressure)
        {
            return true;
        }

        private bool oxygenLevelResponseWarning(int inputOLevel)
        {
            return true;
        }

    }
}
