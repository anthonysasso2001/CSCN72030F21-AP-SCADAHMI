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

        private int autoPilotState;

        //Constructor
        public AutoPilot(string [] fileNames)
        {
            //module array to simplify allocating file names
            HardwareIO[] moduleArray =
                {this.weather,
                this.planeFAV,
                this.planeCPAO,
                this.planeTravelInfo,
                this.planeExtTemp,
                this.planeLiquidLevel,
                this.planeFuelControl,
                this.planeSpeed,
                this.planeIntTemp,
                this.planeAltitude,
                this.planeHeading};

            for (int i=0; i < 11; i++)
            {

            }
        }

        //functions to call HardwareIO abstract functions
        private bool showInfo(HardwareIO inputModule, int inputTime)
        {
            bool moduleOutput = inputModule.display(inputTime);
            return moduleOutput;
        }
        private bool changeInfo(HardwareIO inputModule, string inputData)
        {
            bool moduleOutput = inputModule.modify(inputData);
            return moduleOutput;
        }
        //General / Utility Functions
        //coloured box for state
        private void colouredModuleState(int inputState)
        {
            Console.WriteLine("[");
            if (0 == inputState)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("TRUE");
            }
            else if (1 == inputState)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FALSE");
            }
            else
            {
                //ERROR
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("]");
        }
        private int boolToInt(bool inputBool)
        {
            if (inputBool)
            {
                return 1;
            }
            else if (!inputBool)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        //Main Menu / Sub Menus
        public void Menu()
        {
            Console.WriteLine(
                "Please select a Sub Menu:\n" +
                "1. Sensors Menu\n" +
                "2. Controls Menu\n" +
                "3. Exit Auto Pilot\n");

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

        //Overrides menu / Toggle Autopilot
        bool manualOverrides()
        {
            bool menuLoop = true;
            while (menuLoop)
            {
                //menu options for toggles
                Console.WriteLine("Please select a module to override (by number):\n");
                Console.WriteLine(
                    "1. [{0}] WeatherAPI\n" +
                    "2. [{1}] Force & Vibration\n" +
                    "3. [{2}] Cabin Pressure & Oxygen\n" +
                    "4. [{3}] Travel Info\n" +
                    "5. [{4}] Exterior Temp\n" +
                    "6. [{5}] Liquid Level\n" +
                    "7. [{6}] Fuel Control\n" +
                    "8. [{7}] Plane Speed\n" +
                    "9. [{8}] Interior Temp\n" +
                    "10. [{9}] Altitude\n" +
                    "11. [{10}] Heading\n" +
                    ":",
                    this.weather.getActivity(),
                    this.planeFAV.getActivity(),
                    this.planeCPAO.getActivity(),
                    this.planeTravelInfo.getActivity(),
                    this.planeExtTemp.getActivity(),
                    this.planeLiquidLevel.getActivity(),
                    this.planeFuelControl.getActivity(),
                    this.planeSpeed.getActivity(),
                    this.planeIntTemp.getActivity(),
                    this.planeAltitude.getActivity(),
                    this.planeHeading.getActivity()
                    );

                //get input for menu
                int inputOption = Convert.ToInt32(Console.ReadLine());

                //switch case for menu
                switch (inputOption)
                {
                    case 1:
                        this.weather.toggleActive();
                        Console.WriteLine("Weather API Module toggled to ");
                        colouredModuleState(boolToInt(this.weather.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        this.planeFAV.toggleActive();
                        Console.WriteLine("Force & Vibration Module toggled to ");
                        colouredModuleState(boolToInt(this.planeFAV.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        this.planeCPAO.toggleActive();
                        Console.WriteLine("Cabin Pressure & Oxygen Module toggled to ");
                        colouredModuleState(boolToInt(this.planeCPAO.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        this.planeTravelInfo.toggleActive();
                        Console.WriteLine("Travel Info Module toggled to ");
                        colouredModuleState(boolToInt(this.planeTravelInfo.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 5:
                        this.planeExtTemp.toggleActive();
                        Console.WriteLine("Exterior Temperature Module toggled to ");
                        colouredModuleState(boolToInt(this.planeExtTemp.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 6:
                        this.planeLiquidLevel.toggleActive();
                        Console.WriteLine("Liquid Level Module toggled to ");
                        colouredModuleState(boolToInt(this.planeLiquidLevel.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 7:
                        this.planeFuelControl.toggleActive();
                        Console.WriteLine("Fuel Control Module toggled to ");
                        colouredModuleState(boolToInt(this.planeFuelControl.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 8:
                        this.planeSpeed.toggleActive();
                        Console.WriteLine("Plane Speed Module toggled to ");
                        colouredModuleState(boolToInt(this.planeSpeed.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 9:
                        this.planeIntTemp.toggleActive();
                        Console.WriteLine("Interior Temperature Module toggled to ");
                        colouredModuleState(boolToInt(this.planeIntTemp.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 10:
                        this.planeAltitude.toggleActive();
                        Console.WriteLine("Altitude Module toggled to ");
                        colouredModuleState(boolToInt(this.planeAltitude.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    case 11:
                        this.planeHeading.toggleActive();
                        Console.WriteLine("Heading Module toggled to ");
                        colouredModuleState(boolToInt(this.planeHeading.getActivity()));
                        Console.WriteLine("\n");
                        break;
                    default:
                        Console.WriteLine("Error, Unknown Input\n Please try Again\n");
                        break;
                }
                bool continueLoop = true;
                while (continueLoop)
                {
                    Console.WriteLine("Would you like to continue?\n[y/n]:");
                    char loopOption = Convert.ToChar(Console.ReadLine());
                    if ('y' == loopOption)
                    {
                        continueLoop = false;
                        menuLoop = false;
                    }
                    else if ('n' == loopOption)
                    {
                        continueLoop = false;
                        menuLoop = true;
                    }
                    else
                    {
                        Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                    }
                }
            }

            //unsure what false case to pass, can be worked out later?
            return true;
        }
        bool toggleAutoPilot()
        {
            //array of all modules to simplify toggle
            HardwareIO[] moduleArray =
                {this.weather,
                this.planeFAV,
                this.planeCPAO,
                this.planeTravelInfo,
                this.planeExtTemp,
                this.planeLiquidLevel,
                this.planeFuelControl,
                this.planeSpeed,
                this.planeIntTemp,
                this.planeAltitude,
                this.planeHeading};

            bool menuLoop = true;
            while (menuLoop)
            {
                for(int i = 0; i < moduleArray.Length; i++)
                {
                    if (!moduleArray[i].getActivity())
                    {
                        this.autoPilotState
                    }
                }
                Console.WriteLine("AutoPilot state = ");
                colouredModuleState(this.autoPilotState);
                Console.WriteLine("\nToggle Auto Pilot? [y/n]:");
                char inputOption = Convert.ToChar(Console.ReadLine());

                if ('y' == inputOption)
                {
                    if (0 == this.autoPilotState)
                    {
                        this.autoPilotState = 1;
                    }
                    else
                    {
                        this.autoPilotState = 0;
                    }
                    menuLoop = false;
                }
                else if ('n' == inputOption)
                {
                    //do nothing since they do not want to change it
                    menuLoop = false;
                }
                else
                {
                    Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                }
            }

            //check if module = true and set to off
            for (int i = 0; i < moduleArray.Length; i++)
            {
                if (this.autoPilotState != Convert.ToInt32(moduleArray[i].getActivity()))
                {
                    moduleArray[i].toggleActive();
                }
            }

            //check that they were set correctly
            for (int i = 0; i < moduleArray.Length; i++)
            {
                if (this.autoPilotState != Convert.ToInt32(moduleArray[i].getActivity()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}