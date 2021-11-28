using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSCN72030F21_AP_Classes;

namespace CSCN72030F21_AP_Tests
{
    [TestClass]
    public class AltitudeTests
    {
        [TestMethod]
        public void AUT_ALT_001()
        {
            Altitude testAltitude = new("..\\TestData\\testAltitudeConstructor.txt");
            Assert.IsNotNull(testAltitude);
        }
    }
}