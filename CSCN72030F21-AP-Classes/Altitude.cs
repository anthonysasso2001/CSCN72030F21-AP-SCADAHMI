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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class Altitude : HardwareIO
    {
        private readonly double _minHeightBound;
        private readonly double _maxHeightBound;

        public Altitude(string inputFileName) : base(inputFileName, true)
        {
            this._minHeightBound = 23871.39;
            this._maxHeightBound = 50931.759;
        }

        private double getMinHeightBound()
        {
            return this._minHeightBound;
        }
        private double getMaxHeightBound()
        {
            return this._maxHeightBound;
        }

        public override bool display(int inputTime)
        {
            double[] displayData = this.getAndFormatData(inputTime);
            bool displayState = true;

            for (int i = 1; i < (inputTime + 1); i ++)
            {
                System.Threading.Thread.Sleep(1000);    //wait 1 second before continuing
                if (this.checkHeightBounds(displayData[i]))
                {
                    Console.WriteLine("plane is at {0} feet\n", Math.Round(displayData[i], 2));
                }
                if (!this.checkHeightBounds(displayData[i]))
                {
                    this.heightResponseWarning(displayData[i]);
                    displayState = false;
                }
            }
            return displayState;    //true for no errors, false is a warning was called (errors interrupt and exit so not handled here)
        }

        public override bool modify(string inputValue)
        {
            int fileLines = 15; //15 lines in the file
            double[] startDouble = this.getAndFormatData(fileLines+1);
            double endDouble = Convert.ToDouble(inputValue);

            bool updateState = this.updateDataFile(startDouble[fileLines+1], endDouble, fileLines);

            return updateState;
        }

        public class AltitudeTooLowException : System.Exception
        {
            public AltitudeTooLowException(double inputHeight)
              : base(String.Format("plane altitude is {0} feet under acceptable limit", Math.Round(inputHeight, 2))) { }
        }

        public class AltitudeTooHighException : System.Exception
        {
            public AltitudeTooHighException(double inputHeight)
              : base(String.Format("plane altitude is {0} feet over acceptable limit", Math.Round(inputHeight, 2))) { }
        }

        private double heightWarningDiff(double inputHeight)
        {
            double outputDifferential = 0;
            double minWarningBound = (this.getMinHeightBound() + 5000);
            double maxWarningBound = (this.getMaxHeightBound() - 5000);
            if (this.getMinHeightBound() >= inputHeight) //if altitude is equal to or under 23871.39
            {
                outputDifferential = this.getMinHeightBound() - inputHeight;
                throw new AltitudeTooLowException(outputDifferential);
            }
            else if ((this.getMinHeightBound() < inputHeight) && (minWarningBound >= inputHeight))  //if height is between 23871.39-25871.39
            {
                outputDifferential = inputHeight - (minWarningBound + 1);

            }
            else if ((minWarningBound < inputHeight) && (maxWarningBound > inputHeight)) //if pressure is in normal bounds 25871.39-45931.759
            {
                outputDifferential = 0;   //incase it passes through a valid pressure...
            }
            else if ((this.getMaxHeightBound() > inputHeight) && (maxWarningBound <= inputHeight))    //if pressure is between 45931.759 - 50931.759
            {
                outputDifferential = inputHeight - (maxWarningBound - 1);
            }
            else if (this.getMaxHeightBound() <= inputHeight) //if height is equal to or over 50931.759
            {
                outputDifferential = inputHeight - this.getMaxHeightBound();
                throw new AltitudeTooHighException(outputDifferential);
            }
            return outputDifferential;
        }

        private bool checkHeightBounds(double heightValue)
        {
            double minWarningBound = (this.getMinHeightBound() + 5000);
            double maxWarningBound = (this.getMaxHeightBound() - 5000);
            if (minWarningBound >= heightValue) //if height is under 25871.39
            {
                return false;
            }
            else if (maxWarningBound <= heightValue)   //if height is over 45931.759
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool updateDataFile(double currentHeight, double targetHeight, int iterations)
        {
            Random variation = new Random();

            double[] outputArray = new double[(iterations + 2)];

            double outputValue = currentHeight;
            double incrementMultiplier = 0;
            if (currentHeight != targetHeight)
            {
                incrementMultiplier = (targetHeight - currentHeight) / iterations;      //evaluates to value increments wil step by (slowly increase to the other number)
            }
            else if (currentHeight == targetHeight)
            {
                incrementMultiplier = 0;   //code to use the random sequence instead of slow increase and decrease
            }
            else
            {
                return false;
            }

            for (int i = 0; i <= iterations; i++)
            {
                if (0 == incrementMultiplier)
                {
                    int minRange = -4000;
                    int maxRange = 4000;
                    double upperAmount = variation.Next(minRange, maxRange);
                    double lowerAmount = ((double)variation.Next(0, 999)) / 1000;
                    outputValue = targetHeight + upperAmount + lowerAmount;  //random number +- 4000 from input amount.
                }
                else
                {
                    outputValue = Math.Round(currentHeight + (incrementMultiplier * i), 2);
                }
                outputArray[i] = outputValue;
                //Console.WriteLine("position {0} = {1}", i, outputValue);
            }
            string formattedOutput = "";

            for (int i = 0; i <= iterations; i++)
            {
                formattedOutput += outputArray[i].ToString() + " feet\n";
            }

            bool fileUpdateState = this.fileUpdate(formattedOutput);
            return fileUpdateState;
        }

        private double[] getAndFormatData(int inputTime)
        {
            double[] outputDouble = new double[1 + inputTime];
            outputDouble[0] = inputTime;    //pos 0 is input time for consistency
            double formattedValues = 0;
            int lineNum = 1;
            int iterationCount = 1;
            Regex expectedOutput = new Regex("^([0-9]+.?[0-9]*|.[0-9]+) feet$");    //regex for [any amount of digits] [.] [any amount of digits] [feet]
            //([0-9]+.?[0-9]*|.[0-9]+) feet
            while (iterationCount <= inputTime)
            {
                string unformattedString = this.fileGet(lineNum);
                if (expectedOutput.IsMatch(unformattedString))
                {
                    lineNum++;
                    string[] splitValue = unformattedString.Split(' ');
                    formattedValues = Convert.ToDouble(splitValue[0]);
                    outputDouble[iterationCount] = formattedValues;
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

        private void heightResponseWarning(double inputResponseValue)
        {
            double heightWarningAmount = this.heightWarningDiff(inputResponseValue);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("WARNING ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("plane at {0} feet !! {1} feet out of bounds\n\n", Math.Round(inputResponseValue, 2), Math.Round(heightWarningAmount,2));
        }

    }
}
