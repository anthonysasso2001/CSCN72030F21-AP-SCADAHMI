using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCN72030F21_AP_Classes;

namespace CSCN72030F21_AP_Tests
{
    [TestClass]
    public class CabinPressureAndOxygenTests
    {
        [TestMethod]
        public void AUT_PAO_001()
        {
            CabinPressureAndOxygen testCPAO = new("..\\TestData\\testCPAOConstructor.txt");
            Assert.IsNotNull(testCPAO);
        }

    }
}