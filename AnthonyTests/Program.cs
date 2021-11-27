using System;
using CSCN72030F21_AP_Classes;
namespace AnthonyTests
{
    class Program
    {
        static void AUT_PAO_002()
        {
            string fileName = "..\\TestData\\testCPAOConstructor.txt";
            string testData = "14.83,21\n13,24\n10.4,20\n0,0";
            CabinPressureAndOxygen inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void PAO_USE_001()
        {
            string fileName = "..\\TestData\\testCPAOConstructor.txt";
            string testData = "12.9,21\n13,22\n12,22";
            CabinPressureAndOxygen inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void PAO_USE_002()
        {
            string fileName = "..\\TestData\\testCPAOConstructor.txt";
            string testData = "14.83,21\n13,18\n10.4,24";
            CabinPressureAndOxygen inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }


        static void PAO_USE_003()
        {
            string fileName = "..\\TestData\\testCPAOConstructor.txt";
            string testData = "14.83,21\n13,18\n12.9,21\n0,21";
            CabinPressureAndOxygen inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void AUT_ALT_002()
        {
            string fileName = "..\\TestData\\testAltitudeConstructor.txt";
            string testData = "30000 feet\n29000 feet\n32000 feet\n0 feet";
            Altitude inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_001()
        {
            string fileName = "..\\TestData\\testAltitudeConstructor.txt";
            string testData = "30000 feet\n32000 feet\n29000 feet\n";
            Altitude inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_002()
        {
            string fileName = "..\\TestData\\testAltitudeConstructor.txt";
            string testData = "46000 feet\n24000 feet\n24500 feet";
            Altitude inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_003()
        {
            string fileName = "..\\TestData\\testAltitudeConstructor.txt";
            string testData = "4653.34 feet\n32000 feet\n0 feet\n";
            Altitude inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_004()
        {
            string fileName = "..\\TestData\\testAltitudeConstructor.txt";
            string testData = "4653.34 feet\n32000 feet\n29000 feet\n";
            Altitude inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void ALT_USE_005()
        {
            string fileName = "..\\TestData\\testAltitudeConstructor.txt";
            string testData = "4653.34 feet\n32000 feet\n35000 feet\n";
            Altitude inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[9] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        static void Main(string[] args)
        {
            Console.Write("input testname: ");
            string inputTest = Console.ReadLine();

            bool continueLoop = true;
            while (continueLoop)
            {
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
