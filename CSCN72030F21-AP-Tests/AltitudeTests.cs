using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCN72030F21_AP_Classes;

namespace CSCN72030F21_AP_Tests
{
    [TestClass]
    public class AltitudeTests
    {
        [TestMethod]
        public void ALT_UNIT_001_createModule_moduleNotNull_Success()
        {
            Altitude testAltitude = new("..\\TestData\\testAltitudeConstructor.txt");
            Assert.IsNotNull(testAltitude);
        }

        [TestMethod]
        public void ALT_USE_001()
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

        [TestMethod]
        public void ALT_USE_002()
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

        [TestMethod]
        public void ALT_USE_003()
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

        [TestMethod]
        public void ALT_USE_004()
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

        [TestMethod]
        public void ALT_USE_005()
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
    }
}