using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class CabinPressureAndOxygen : HardwareIO
    {
        private readonly double _minPressureBound;
        private readonly double _maxPressureBound;
        private readonly int _minOLevelBound;
        private readonly int _maxOLevelBound;

        public CabinPressureAndOxygen(string inputFileName) : base(inputFileName, false)
        {
            this._minPressureBound = 5;  //5psi danger, 9psi warning, 11-12 psi normal, 14 psi warning, 17 psi danger
            this._maxPressureBound = 17;
            this._minOLevelBound = 16;   //<16% = danger, 16-19% warning, 19-23%  normal, 23-25% warning, >25% = danger
            this._maxOLevelBound = 25;
        }

        private double getMinPressureBound()
        {
            return this._minPressureBound;
        }
        private double getMaxPressureBound()
        {
            return this._maxPressureBound;
        }

        private int getMinOxygenBound()
        {
            return this._minOLevelBound;
        }
        private int getMaxOxygenBound()
        {
            return this._maxOLevelBound;
        }

        public override bool display(int inputTime)
        {
            double[] displayData = this.getAndFormatData(inputTime);
            bool displayState = true;
            for (int i = 1; i < (2*inputTime+1); i+=2)
            {
                System.Threading.Thread.Sleep(1000);    //wait 1 second before continuing
                if (this.checkPressureBounds(displayData[i]) && this.checkOxygenBounds(Convert.ToInt32(displayData[i + 1])))
                {
                    Console.WriteLine("plane Pressure: {0}, Oxygen Level: {1}\n", Math.Round(displayData[i],2), displayData[i + 1]);
                }
                if (!this.checkPressureBounds(displayData[i]))
                {
                    double[] responseValues = new double[] { displayData[i], displayData[i + 1] };
                    this.pressureResponseWarning(responseValues);
                    displayState = false;
                }
                if (!this.checkOxygenBounds(Convert.ToInt32(displayData[i+1])))
                {
                    double[] responseValues = new double[] { displayData[i], displayData[i + 1] };
                    this.oxygenLevelResponseWarning(responseValues);
                    displayState = false;
                }
            }
            return displayState;    //true for no errors, false is a warning was called (errors interrupt and exit so not handled here)
        }

        public override bool modify(string inputValue)
        {
            throw new ArgumentException();  //should not access this throw exception    
        }

        public class PressureTooLowException : System.Exception
        {
            public PressureTooLowException(double inputPressure)
              : base(String.Format("plane pressure is {0} psi under acceptable limit", Math.Round(inputPressure,2))) { }
        }

        public class PressureTooHighException : System.Exception
        {
            public PressureTooHighException(double inputPressure)
              : base(String.Format("plane pressure is {0} psi over acceptable limit", Math.Round(inputPressure,2))) { }
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
            double minWarningBound = (this.getMinPressureBound() + 4);
            double maxWarningBound = (this.getMaxPressureBound() - 3);
            if (this.getMinPressureBound() >= inputPressure) //if pressure is equal to or under 5
            {
                outputDifferential = this.getMinPressureBound() - inputPressure;
                throw new PressureTooLowException(outputDifferential);
            }
            else if ((this.getMinPressureBound() < inputPressure) && (minWarningBound >= inputPressure))  //if pressure is between 6-9
            {
                outputDifferential = inputPressure - (minWarningBound + 1);
                
            }
            else if ((minWarningBound < inputPressure) && (maxWarningBound > inputPressure)) //if pressure is in normal bounds 10-14
            {
               outputDifferential = 0;   //incase it passes through a valid pressure...
            }
            else if ((this.getMaxPressureBound() > inputPressure) && (maxWarningBound <= inputPressure))    //if pressure is between 15-16
            {
                outputDifferential = inputPressure - (maxWarningBound - 1);
            }
            else if (this.getMaxPressureBound() <= inputPressure) //if pressure is equal to or over 17
            {
                outputDifferential = inputPressure - this.getMaxPressureBound();
                throw new PressureTooHighException(outputDifferential);
            }
            return outputDifferential;
        }

        private int oxygenWarningDiff(int inputOxygen)    //<16% = danger, 16-19% warning, 19-23%  normal, 23-25% warning, >25% = danger
        {
            int outputDifferential = 0;
            int minWarningBound = (this.getMinOxygenBound() + 3);
            int maxWarningBound = (this.getMaxOxygenBound() - 2);
            if (this.getMinOxygenBound() >= inputOxygen) //if pressure is equal to or under 16%
            {
                outputDifferential = inputOxygen - (this.getMinOxygenBound() + 1);
                throw new OxygenTooLowException(outputDifferential);
            }
            else if ((this.getMinOxygenBound() < inputOxygen) && (minWarningBound >= inputOxygen))  //if oxygen level is between 17-19%
            {
                outputDifferential = inputOxygen - (minWarningBound + 1);
            }
            else if ((this.getMinOxygenBound() < inputOxygen) && (maxWarningBound > inputOxygen)) //if oxygen levels are in normal bounds (20-23%)
            {
                outputDifferential = 0;   //incase it passes through a valid O level...
            }
            else if ((this.getMaxOxygenBound() > inputOxygen) && (maxWarningBound <= inputOxygen))    //if oxygen is 24%
            {
                outputDifferential = inputOxygen - (maxWarningBound - 1);
            }
            else if (this.getMaxOxygenBound() <= inputOxygen) //if oxygen is equal to or above 25%
            {
                outputDifferential = inputOxygen - this.getMaxOxygenBound()-1;
                throw new OxygenTooHighException(outputDifferential);
            }
            return outputDifferential;
        }

        private bool checkPressureBounds(double pressureValue)
        {
            double minWarningBound = (this.getMinPressureBound() + 4);
            double maxWarningBound = (this.getMaxPressureBound() - 3);
            if (minWarningBound >= pressureValue) //if pressure is under 9
            {
                return false;
            }
            else if (maxWarningBound <= pressureValue)   //if pressure is over 15
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
            int minWarningBound = (this.getMinOxygenBound() + 3);
            int maxWarningBound = (this.getMaxOxygenBound() - 2);
            if (minWarningBound >= oxygenValue) //if oxygen is under 19%
            {
                return false;
            }
            else if (maxWarningBound <= oxygenValue)   //if oxygen is over 23%
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
            double[] outputDouble = new double[1+(2*inputTime)];
            outputDouble[0] = inputTime;    //pos 0 is input time for consistency
            double[] formattedValues = new double[2];
            int outputCount = 1;
            int lineNum = 1;
            int iterationCount = 0;
            Regex expectedOutput = new Regex("^([0-9]+.?[0-9]*|.[0-9]+),[0-9]+$");    //regex for [any amount of digits] [.] [any amount of digits] [,] [any amount of digits]
            //([0-9]+.?[0-9]*|.[0-9]+),[0-9]+
            while (iterationCount < inputTime)
            {
                string unformattedString = this.fileGet(lineNum);
                if (expectedOutput.IsMatch(unformattedString))
                {
                    lineNum++;
                    formattedValues = (Array.ConvertAll(unformattedString.Split(','), Double.Parse));
                    outputDouble[outputCount] = formattedValues[0];
                    outputCount++;
                    outputDouble[outputCount] = formattedValues[1];
                    outputCount++;
                    iterationCount++;
                }
                else if ("LINE_ERROR Sequence contains no elements".Equals(unformattedString))
                {
                    lineNum = 1;
                }
                else
                {
                    throw new FileIOFormatException(lineNum, this.getFileName());
                }
            }
            return outputDouble;
        }

        private void pressureResponseWarning(double[] inputResponseValues)  //warning for pressure values
        {
            double pressureWarningAmount = this.pressureWarningDiff(inputResponseValues[0]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("WARNING ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("plane pressure: {0} psi, Oxygen Level: {1}%\n Pressure is {2} psi out of bound\n\n", Math.Round(inputResponseValues[0],2), inputResponseValues[1], Math.Round(pressureWarningAmount,2));
        }

        private void oxygenLevelResponseWarning(double[] inputResponseValues)   //warning for oxygen levels
        {
            double oxygenWarningAmount = this.oxygenWarningDiff(Convert.ToInt32(inputResponseValues[1]));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("WARNING ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("plane pressure: {0} psi, Oxygen Level: {1}%\n Oxygen is {2}% out of bounds\n\n", Math.Round(inputResponseValues[0],2), inputResponseValues[1], oxygenWarningAmount);
        }
    }
}
