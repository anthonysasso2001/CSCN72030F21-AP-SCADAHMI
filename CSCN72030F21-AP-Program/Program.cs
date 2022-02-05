//Project III - Software Development
//Conestoga College
//Sep. 2021 - Dec. 2021
//Contributers:
//              Thi Huong Tra Le (Rachel)
//              Anthony Sasso
//              Navdeep Mangat
//              Eazaz Jakda
using System;
using System.IO;
using CSCN72030F21_AP_Classes;

namespace CSCN72030F21_AP_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataFile = "..\\Data\\";   //"macro for file path

            string[] fileArray = new string[11];
            fileArray[0] = (dataFile + "WeatherAPIData.txt");
            fileArray[1] = (dataFile + "ForceAndVibrationData.txt");
            fileArray[2] = (dataFile + "CabinPressureAndOxygenData.txt");
            fileArray[3] = (dataFile + "TravelInfoData.txt");
            fileArray[4] = (dataFile + "ExteriorTempData.txt");
            fileArray[5] = (dataFile + "LiquidLevelData.txt");
            fileArray[6] = (dataFile + "FuelControlData.txt");
            fileArray[7] = (dataFile + "AirSpeedData.txt");
            fileArray[8] = (dataFile + "InteriorTempData.txt");
            fileArray[9] = (dataFile + "AltitudeData.txt");
            fileArray[10] = (dataFile + "HeadingData.txt");

            //preset data for the files
            string[] startupData = {
                //WeatherAPI
                "30,16,8\n" +
                "40,24,4\n" +
                "60,30,2\n" +
                "80,40,0\n" +
                "95,8,5\n",

                //Force and Vibration
                "7,8\n" +
                "7,8\n" +
                "8,8\n" +
                "8,7\n" +
                "10,7\n",

                //Cabin Pressure & Oxygen
                "10.4,20\n" +
                "14.83,18\n" +
                "8.4,21\n" +
                "12.9,21\n" +
                "13,22\n" +
                "11.8,24\n" +
                "8.12,21\n" +
                "16,21\n" +
                "12,22\n" +
                "0,5\n" +
                "20,41\n",

                //Travel Info
                "3000,3.33\n" +
                "2500,2.78\n" +
                "2000,2.22\n" +
                "1500,1.67\n" +
                "1000,1.11\n" +
                "500,0.56\n" +
                "250,0.27\n",

                //Exterior Temperature
                "34.0\n" +
                "33.8\n" +
                "33.8\n" +
                "33.0\n" +
                "32.7\n" +
                "33.0\n",

                //Liquid Level
                "88\n" +
                "87\n" +
                "86\n" +
                "85\n" +
                "84\n",

                //Fuel Control
                "30\n" +
                "29\n" +
                "28\n" +
                "27\n" +
                "26\n" +
                "25\n" +
                "24\n" +
                "23\n" +
                "22\n" +
                "21\n" +
                "20\n",

                //Air Speed
                "300\n" +
                "350\n" +
                "400\n" +
                "450\n" +
                "500\n" +
                "550\n" +
                "600\n" +
                "650\n" +
                "700\n" +
                "750\n",

                //Interior Temperature
                "22\n" +
                "21\n" +
                "20\n" +
                "19\n" +
                "18\n" +
                "17\n" +
                "16\n" +
                "15\n",

                //Altitude
                "26562.95 feet\n" +
                "27525.42 feet\n" +
                "28487.89 feet\n" +
                "29450.36 feet\n" +
                "30412.83 feet\n" +
                "31375.3 feet\n" +
                "32337.77 feet\n" +
                "33300.24 feet\n" +
                "34262.71 feet\n" +
                "35225.18 feet\n" +
                "36187.65 feet\n" +
                "37150.12 feet\n" +
                "38112.59 feet\n" +
                "39075.06 feet\n" +
                "40037.53 feet\n" +
                "41000 feet\n",
                
                //Heading
                "216.2\n" +
                "222.2\n" +
                "228.2\n" +
                "234.2\n" +
                "240.2\n"};

            //checks if file exists and if it doesn't creates that file and populates with data
            if (!Directory.Exists(dataFile))
            {
                Directory.CreateDirectory(dataFile);
            }
            for (int i = 0; i < 11; i++)
            {
                if (!File.Exists(fileArray[i]))
                {
                    File.WriteAllText(fileArray[i], startupData[i]);
                }
            }

            AutoPilot scadaHmi = new(fileArray);
            scadaHmi.Menu();

            //testing for HardwareIO
            
            //HardwareIO test = new HardwareIO((dataFile+"test.txt"), true);
            //test.fileUpdate("testone\ntesttwo\ntestThree\n");

            //Console.WriteLine("Line 2 is: {0}",test.fileGet(4));
            
        }
    }
}

/*
using System;
using CSCN72030F21_AP_Classes;

namespace CSCN72030F21_AP_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            const string dataFile = "..\\Data\\";   //"macro for file path

            string[] fileArray=new string[11];
            fileArray[0] = (dataFile + "WeatherAPIData.txt");
            fileArray[1] = (dataFile + "ForceAndVibrationData.txt");
            fileArray[2] = (dataFile + "CabinPressureAndOxygenData.txt");
            fileArray[3] = (dataFile + "TravelInfoData.txt");
            fileArray[4] = (dataFile + "ExteriorTempData.txt");
            fileArray[5] = (dataFile + "LiquidLevelData.txt");
            fileArray[6] = (dataFile + "FuelControlData.txt");
            fileArray[7] = (dataFile + "AirSpeedData.txt");
            fileArray[8] = (dataFile + "InteriorTempData.txt");
            fileArray[9] = (dataFile + "AltitudeData.txt");
            fileArray[10] = (dataFile + "HeadingData.txt");

            AutoPilot scadaHmi = new(fileArray);
            scadaHmi.Menu();

            //testing for HardwareIO
            
            //HardwareIO test = new HardwareIO((dataFile+"test.txt"), true);
            //test.fileUpdate("testone\ntesttwo\ntestThree\n");

            //Console.WriteLine("Line 2 is: {0}",test.fileGet(4));
            
        }
    }
}
*/