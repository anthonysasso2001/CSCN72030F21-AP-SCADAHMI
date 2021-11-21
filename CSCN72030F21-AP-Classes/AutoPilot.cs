using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    class AutoPilot
    {
        private WeatherAPI weather;
        private ForceAndVibration planeFAV;
        private CabinPressureAndOxygen planeCPAO;
        private TravelInfo planeTravelInfo;
        private ExteriorTemp planeExtTemp;
        private LiquidLevel planeLiquidLevel;
        private FuelControl planeFuelControl;
        private AirSpeed planeSpeed;
        private InteriorTemp planeIntTemp;
        private Altitude planeAltitude;
        private Heading planeHeading;

        //Constructor
        public AutoPilot(string fileNames[])
        {

        }

        //functions to call HardwareIO abstract functions
        private bool showInfo(HardwareIO inputModule)
        {
            return true;
        }
        private bool changeInfo(HardwareIO inputModule, string inputData)
        {
            return true;
        }

        //Main Menu / Sub Menus
        public void Menu()
        {

        }
        //Sensor Menu & Options
        private void SensorMenu()
        {

        }
        private bool WeatherAPISensorOption()
        {
            return true;
        }
        private bool ForceAndVibrationSensorOption()
        {
            return true;
        }
        private bool CabinPressureAndOxygenSensorOption()
        {
            return true;
        }
        private bool TravelInfoSensorOption()
        {
            return true;
        }
        private bool ExteriorTempSensorOption()
        {
            return true;
        }
        private bool LiquidLevelSensorOption()
        {
            return true;
        }
        //Control Menu & Options
        private void ControlMenu()
        {

        }
        private bool FuelControlControlOption()
        {
            return true;
        }
        private bool AirSpeedControlOption()
        {
            return true;
        }
        private bool CabinTempControlOption()
        {
            return true;
        }
        private bool AltitudeControlOption()
        {
            return true;
        }
        private bool HeadingControlOption()
        {
            return true;
        }
        //Overrides / Toggle Autopilot
        bool manualOverrides()
        {
            return true;
        }
        bool toggleAutoPilot()
        {
            return true;
        }
    }
}
