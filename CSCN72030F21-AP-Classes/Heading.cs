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

//Eric Fischer

namespace CSCN72030F21_AP_Classes {
    public class Heading : HardwareIO {
        private double currentHeading;
        public Heading(string inputFileName) : base(inputFileName, true) {
            this.currentHeading = 0;
        }

        public string loadData(int position) {
            string dataString = fileGet(position);
            return dataString;
        }

        public override bool display(int inputTime) {
            
            for(int i = 1; i <= inputTime; i++) {
                //5 lines in the weatherAPI.txt
                //Could improve this if() statement by making it modular
                if (i > 5) {
                    i = 1;
                    inputTime = inputTime - 5;
                }

                string loadedData = loadData(i);

                currentHeading = Convert.ToDouble(loadedData);
                int headingStatus = headingCheck(currentHeading);

                if (headingStatus == 0) {
                    //successful print
                    Console.Write("The Heading is: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0}", currentHeading);
                    Console.ForegroundColor = ConsoleColor.Gray;
                } else {
                    headingWarning(headingStatus);
                }

                System.Threading.Thread.Sleep(1000);
            }


            return true;
        }

        private int headingCheck(double heading) {
            if (heading > 360) {
                return 1;
            } else if (heading < 0) {
                return -1;
            }
            return 0;
        }

        private void headingWarning(int headingStatus) {
            if (headingStatus == 1) {
                //above
                Console.WriteLine("The Heading value is above the acceptable range.");
            } else if (headingStatus == -1) {
                //below
                Console.WriteLine("The Heading value is below the acceptable range.");
            }

        }

        public override bool modify(string inputValue) {

            bool updateStatus = this.fileUpdate(inputValue);
            return updateStatus;

        }
    }
}
