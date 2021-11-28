using System;
using System.IO;
using CSCN72030F21_AP_Classes;
namespace AnthonyTests
{
    class Program
    {
        static void AUT_PAO_002()
        {
            string fileName = "..\\TestData\\testCPAOALT002.txt";
            string testData = "14.83,21\n13,24\n10.4,20\n0,0";

            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void PAO_USE_001()
        {
            string fileName = "..\\TestData\\testCPAOUSE001.txt";
            string testData = "12.9,21\n13,22\n12,22";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void PAO_USE_002()
        {
            string fileName = "..\\TestData\\testCPAOUSE002.txt";
            string testData = "14.83,21\n13,18\n10.4,24";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }


        static void PAO_USE_003()
        {
            string fileName = "..\\TestData\\testCPAOUSE003.txt";
            string testData = "14.83,21\n13,18\n12.9,21\n0,21";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void AUT_ALT_002()
        {
            string fileName = "..\\TestData\\testAltitudeALT002.txt";
            string testData = "30000 feet\n24000 feet\n32000 feet\n0 feet";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void AUT_ALT_003()
        {
            string fileName = "..\\TestData\\testAltitudeALT003.txt";
            string testData = "0 feet";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_001()
        {
            string fileName = "..\\TestData\\testAltitudeUSE001.txt";
            string testData = "30000 feet\n32000 feet\n29000 feet\n";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_002()
        {
            string fileName = "..\\TestData\\testAltitudeUSE002.txt";
            string testData = "46000 feet\n24000 feet\n24500 feet";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_003()
        {
            string fileName = "..\\TestData\\testAltitudeUSE003.txt";
            string testData = "46000.34 feet\n32000 feet\n0 feet\n";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_004()
        {
            string fileName = "..\\TestData\\testAltitudeUSE004.txt";
            string testData = "4653.34 feet\n32000 feet\n29000 feet\n";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_005()
        {
            string fileName = "..\\TestData\\testAltitudeUSE005.txt";
            string testData = "4653.34 feet\n32000 feet\n35000 feet\n";
            File.WriteAllText(fileName, testData);
            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void Main(string[] args)
        {
            
            if (!Directory.Exists("..\\TestData\\"))
            {
                Directory.CreateDirectory("..\\TestData\\");
            }
            bool continueLoop = true;
            while (continueLoop)
            {
                Console.Write("input testname: ");
                string inputTest = Console.ReadLine();
                switch (inputTest)
                {
                    case "AUT_PAO_002":
                        AUT_PAO_002();
                        break;
                    case "PAO_USE_001":
                        PAO_USE_001();
                        break;
                    case "PAO_USE_002":
                        PAO_USE_002();
                        break;
                    case "PAO_USE_003":
                        PAO_USE_003();
                        break;
                    case "AUT_ALT_002":
                        AUT_ALT_002();
                        break;
                    case "AUT_ALT_003":
                        AUT_ALT_003();
                        break;
                    case "ALT_USE_001":
                        ALT_USE_001();
                        break;
                    case "ALT_USE_002":
                        ALT_USE_002();
                        break;
                    case "ALT_USE_003":
                        ALT_USE_003();
                        break;
                    case "ALT_USE_004":
                        ALT_USE_004();
                        break;
                    case "ALT_USE_005":
                        ALT_USE_005();
                        break;
                    default:
                        continueLoop = false;
                        break;
                }
            }
        }
    }
}