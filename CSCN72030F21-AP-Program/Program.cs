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
            /*
            HardwareIO test = new HardwareIO((dataFile+"test.txt"), true);
            test.fileUpdate("testone\ntesttwo\ntestThree\n");

            Console.WriteLine("Line 2 is: {0}",test.fileGet(4));
            */
        }
    }
}