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
            string[] startupData = {
                "30,16,8\n40,24,4\n60,30,2\n80,40,0\n95,8,5",
                "1\n",
                "10.4,20\n14.83,18\n8.4,21\n12.9,21\n13,22\n11.8,24\n8.12,21\n16,21\n12,22\n0,5\n20,41",
                "3000,3.33\n2500,2.78\n2000,2.22\n1500,1.67\n1000,1.11\n500,0.56\n250,0.27",
                "34.0\n33.8\n33.8\n33.0\n32.7\n33.0",
                "88\n87\n86\n85\n84",
                "30\n29\n28\n27\n26\n25\n24\n23\n22\n21\n20",
                "7\n",
                "22\n21\n20\n19\n18\n17\n16\n15",
                "26562.95 feet\n27525.42 feet\n28487.89 feet\n29450.36 feet\n30412.83 feet\n31375.3 feet\n32337.77 feet\n33300.24 feet\n34262.71 feet\n35225.18 feet\n36187.65 feet\n37150.12 feet\n38112.59 feet\n39075.06 feet\n40037.53 feet\n41000 feet",
                "216.2\n222.2\n228.2\n234.2\n240.2"};
            for (int i = 0; i < 11; i++)
            {
                if (!File.Exists(fileArray[i]))
                {

                    //File.Create(fileArray[i]);


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