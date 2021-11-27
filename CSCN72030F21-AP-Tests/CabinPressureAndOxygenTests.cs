using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCN72030F21_AP_Classes;

namespace CSCN72030F21_AP_Tests
{
    [TestClass]
    public class CabinPressureAndOxygenTests
    {
        [TestMethod]
        public void PAO_UNIT_001_createModule_moduleNotNull_success()
        {
            CabinPressureAndOxygen testCPAO = new("..\\TestData\\testCPAOConstructor.txt");
            Assert.IsNotNull(testCPAO);
        }

        
        public void PAO_USE_001()
        {
            string fileName = "..\\TestData\\testCPAOConstructor.txt";
            string testData = "12.9,21\n13,22\n10.4,20\n";
            CabinPressureAndOxygen inputTestData = new(fileName);
            inputTestData.fileUpdate(testData);

            string[] fileNames = new string[11];
            fileNames[2] = fileName;
            AutoPilot testMenu = new(fileNames);
            testMenu.Menu();
        }

        
        public void PAO_USE_002()
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

        
        public void PAO_USE_003()
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
    }
}