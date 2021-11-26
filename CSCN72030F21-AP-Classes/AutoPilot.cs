using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCN72030F21_AP_Classes
{
    public class AutoPilot
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
            //instantiate all modules using filename array...
            this.weather = new(fileNames[0]);
            this.planeFAV = new(fileNames[1]);
            this.planeCPAO = new(fileNames[2]);
            this.planeTravelInfo = new(fileNames[3]);
            this.planeExtTemp = new(fileNames[4]);
            this.planeLiquidLevel = new(fileNames[5]);
            this.planeFuelControl = new(fileNames[6]);
            this.planeSpeed = new(fileNames[7]);
            this.planeIntTemp = new(fileNames[8]);
            this.planeAltitude = new(fileNames[9]);
            this.planeHeading = new(fileNames[10]);
            
            //set to true to start
            this.autoPilotState = 1;
            
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
            Console.Write("[");
            if (0 == inputState)    //inactive
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Manual");
            }
            else if (1 == inputState)   //active
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Active");
            }
            else if (2 == inputState)   //mix of active and inactive
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("CUSTOM");
            }
            else
            {
                //nothing
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("]");
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
            bool menuLoop = true;
            while (menuLoop)
            {
                bool returnFromSub = false;
                Console.WriteLine(
                    "Please select a Sub Menu:\n" +
                    "0. Exit Auto Pilot\n" +
                    "1. Sensors Menu\n" +
                    "2. Controls Menu\n" +
                    "3. Manual Overrides\n" +
                    "4. Toggle AutoPilot\n");
                Console.Write(":");

                string menuOption = Console.ReadLine();

                switch (menuOption)
                {
                    case "0":
                        bool exitLoop = true;
                        while (exitLoop)
                        {
                            Console.WriteLine("Are you sure you want to exit?\n[y/n]: ");
                            string loopOption = Console.ReadLine();
                            if ("y" == loopOption)
                            {
                                exitLoop = false;
                                return;
                            }
                            else if ("n" == loopOption)
                            {
                                //do nothing...
                                exitLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                            }
                        }
                        break;
                    case "1":
                        this.SensorMenu();
                        returnFromSub = true;
                        break;

                    case "2":
                        this.ControlMenu();
                        returnFromSub = true;
                        break;

                    case "3":
                        this.manualOverrides();
                        returnFromSub = true;
                        break;

                    case "4":
                        this.toggleAutoPilot();
                        returnFromSub = true;
                        break;

                    default:
                        Console.WriteLine("Error, Unknown Input\n Please try Again\n");
                        break;
                }
                if (false == returnFromSub)
                {

                    bool continueLoop = true;
                    while (continueLoop)
                    {
                        Console.WriteLine("Would you like to continue?\n[y/n]:");
                        string loopOption = Console.ReadLine();
                        if ("y" == loopOption)
                        {
                            continueLoop = false;
                            menuLoop = true;
                        }
                        else if ("n" == loopOption)
                        {
                            continueLoop = false;
                            menuLoop = false;
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                        }
                    }
                }
            }
        }

        //Sensor Menu & Options
        private void SensorMenu()
        {
            bool sensorLoop = true;
            while (sensorLoop)
            {

                Console.WriteLine("Please select a sensor module to access (by number):\n");

                Console.WriteLine("0. Exit Sensor Menu\n");

                Console.Write("1. ");
                colouredModuleState(boolToInt(this.weather.getActivity()));
                Console.WriteLine("WeatherAPI\n"); 

                Console.Write("2. ");
                colouredModuleState(boolToInt(this.planeFAV.getActivity()));
                Console.WriteLine("Force & Vibration\n"); 

                Console.Write("3. ");
                colouredModuleState(boolToInt(this.planeCPAO.getActivity()));
                Console.WriteLine("Cabin Pressure & Oxygen\n");

                Console.Write("4. ");
                colouredModuleState(boolToInt(this.planeTravelInfo.getActivity()));
                Console.WriteLine("Travel Info\n");

                Console.Write("5. ");
                colouredModuleState(boolToInt(this.planeExtTemp.getActivity()));
                Console.WriteLine("Exterior Temp\n");

                Console.Write("6. ");
                colouredModuleState(boolToInt(this.planeLiquidLevel.getActivity()));
                Console.WriteLine("Liquid Level\n");

                Console.Write(":");

                //get input for menu
                string inputOption = Console.ReadLine();
                switch (inputOption)
                {
                    case "0":
                        bool exitLoop = true;
                        while (exitLoop)
                        {
                            Console.WriteLine("Are you sure you want to exit?\n[y/n]: ");
                            string loopOption = Console.ReadLine();
                            if ("y" == loopOption)
                            {
                                exitLoop = false;
                                return;
                            }
                            else if ("n" == loopOption)
                            {
                                //do nothing...
                                exitLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                            }
                        }
                        break;

                    case "1":
                        if (this.weather.getActivity())
                        {
                            this.WeatherAPISensorOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "2":
                        if (this.planeFAV.getActivity())
                        {
                            this.ForceAndVibrationSensorOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "3":
                        if (this.planeCPAO.getActivity())
                        {
                            this.CabinPressureAndOxygenSensorOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "4":
                        
                        if (this.planeTravelInfo.getActivity())
                        {
                            this.TravelInfoSensorOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "5":
                        
                        if (this.planeExtTemp.getActivity())
                        {
                            this.ExteriorTempSensorOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "6":
                        
                        if (this.planeLiquidLevel.getActivity())
                        {
                            this.LiquidLevelSensorOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    default:
                        Console.WriteLine("Error, Unknown Input\n Please try Again\n");
                        break;
                }

                bool continueLoop = true;
                while (continueLoop) {
                    Console.WriteLine("Would you like to continue?\n[y/n]:");
                    string loopOption = Console.ReadLine();
                    if ("y" == loopOption)
                    {
                        continueLoop = false;
                        sensorLoop = true;
                    }
                    else if ("n" == loopOption)
                    {
                        continueLoop = false;
                        sensorLoop = false;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                    }
                }
            }
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
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("Enter the total time (seconds) that you want to view the exterior temperature, or press q to return to previous menu:");
                String userInput = Console.ReadLine();
                int inputTime = Int32.Parse(userInput);

                if (userInput == "q")
                    return false;
                else if (inputTime < 1)
                {
                    Console.WriteLine("Invalid viewing time!");
                    continue;
                }
                else
                {
                    planeExtTemp.display(inputTime);
                    repeat = false;
                }
            }
            return true;
        }
        private bool LiquidLevelSensorOption()
        {
            return true;
        }

        //Control Menu & Options
        private void ControlMenu()
        {
            bool controlLoop = true;
            while (controlLoop)
            {
                Console.WriteLine("Please select a control module to access (by number):\n");

                Console.WriteLine("0. Exit Control Menu\n");

                Console.Write("1. ");
                colouredModuleState(boolToInt(this.planeFuelControl.getActivity()));
                Console.WriteLine("Fuel Control\n");

                Console.Write("2. ");
                colouredModuleState(boolToInt(this.planeSpeed.getActivity()));
                Console.WriteLine("Plane Speed\n");

                Console.Write("3. ");
                colouredModuleState(boolToInt(this.planeIntTemp.getActivity()));
                Console.WriteLine("Interior Temp\n");

                Console.Write("4. ");
                colouredModuleState(boolToInt(this.planeAltitude.getActivity()));
                Console.WriteLine("Altitude\n");

                Console.Write("5. ");
                colouredModuleState(boolToInt(this.planeHeading.getActivity()));
                Console.WriteLine("Heading\n");

                Console.Write(":");

                //get input for menu
                string inputOption = Console.ReadLine();

                switch (inputOption)
                {
                    case "0":
                        bool exitLoop = true;
                        while (exitLoop)
                        {
                            Console.WriteLine("Are you sure you want to exit?\n[y/n]: ");
                            string loopOption = Console.ReadLine();
                            if ("y" == loopOption)
                            {
                                exitLoop = false;
                                return;
                            }
                            else if ("n" == loopOption)
                            {
                                //do nothing...
                                exitLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                            }
                        }
                        break;
                    case "1":
                        if (this.planeFuelControl.getActivity())
                        {
                            this.FuelControlControlOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "2":
                        if (this.planeSpeed.getActivity())
                        {
                            this.AirSpeedControlOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "3":
                        if (this.planeIntTemp.getActivity())
                        {
                            this.CabinTempControlOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "4":
                        if (this.planeAltitude.getActivity())
                        {
                            this.AltitudeControlOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    case "5":
                        if (this.planeHeading.getActivity())
                        {
                            this.HeadingControlOption();
                        }
                        else
                        {
                            Console.WriteLine("Manual override active, auto pilot is disabled for this module\n");
                        }
                        break;

                    default:
                        Console.WriteLine("Error, Unknown Input\n Please try Again\n");
                        break;
                }
                bool continueLoop = true;
                while (continueLoop)
                {
                    Console.WriteLine("Would you like to continue?\n[y/n]:");
                    string loopOption = Console.ReadLine();
                    if ("y" == loopOption)
                    {
                        continueLoop = false;
                        controlLoop = true;
                    }
                    else if ("n" == loopOption)
                    {
                        continueLoop = false;
                        controlLoop = false;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                    }
                }
            }
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
            bool overrideLoop = true;
            while (overrideLoop)
            {
                //menu options for toggles
                Console.WriteLine("Please select a module to override (by number):\n");

                Console.WriteLine("0. Exit Manual Override Menu\n");

                Console.Write("1. ");
                colouredModuleState(boolToInt(this.weather.getActivity()));
                Console.WriteLine("WeatherAPI\n");

                Console.Write("2. ");
                colouredModuleState(boolToInt(this.planeFAV.getActivity()));
                Console.WriteLine("Force & Vibration\n");

                Console.Write("3. ");
                colouredModuleState(boolToInt(this.planeCPAO.getActivity()));
                Console.WriteLine("Cabin Pressure & Oxygen\n");

                Console.Write("4. ");
                colouredModuleState(boolToInt(this.planeTravelInfo.getActivity()));
                Console.WriteLine("Travel Info\n");

                Console.Write("5. ");
                colouredModuleState(boolToInt(this.planeExtTemp.getActivity()));
                Console.WriteLine("Exterior Temp\n");

                Console.Write("6. ");
                colouredModuleState(boolToInt(this.planeLiquidLevel.getActivity()));
                Console.WriteLine("Liquid Level\n");

                Console.Write("7. ");
                colouredModuleState(boolToInt(this.planeFuelControl.getActivity()));
                Console.WriteLine("Fuel Control\n");

                Console.Write("8. ");
                colouredModuleState(boolToInt(this.planeSpeed.getActivity()));
                Console.WriteLine("Plane Speed\n");

                Console.Write("9. ");
                colouredModuleState(boolToInt(this.planeIntTemp.getActivity()));
                Console.WriteLine("Interior Temp\n");

                Console.Write("10. ");
                colouredModuleState(boolToInt(this.planeAltitude.getActivity()));
                Console.WriteLine("Altitude\n");

                Console.Write("11. ");
                colouredModuleState(boolToInt(this.planeHeading.getActivity()));
                Console.WriteLine("Heading\n");

                Console.Write(":");
                //get input for menu
                string inputOption = Console.ReadLine();

                //switch case for menu
                switch (inputOption)
                {
                    case "0":
                        bool exitLoop = true;
                        while (exitLoop)
                        {
                            Console.WriteLine("Are you sure you want to exit?\n[y/n]: ");
                            string loopOption = Console.ReadLine();
                            if ("y" == loopOption)
                            {
                                exitLoop = false;
                                return true;
                            }
                            else if ("n" == loopOption)
                            {
                                //do nothing...
                                exitLoop = false;
                            }
                            else
                            {
                                Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                            }
                        }
                        break;

                    case "1":
                        this.weather.toggleActive();
                        Console.WriteLine("Weather API Module toggled to ");
                        colouredModuleState(boolToInt(this.weather.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "2":
                        this.planeFAV.toggleActive();
                        Console.WriteLine("Force & Vibration Module toggled to ");
                        colouredModuleState(boolToInt(this.planeFAV.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "3":
                        this.planeCPAO.toggleActive();
                        Console.WriteLine("Cabin Pressure & Oxygen Module toggled to ");
                        colouredModuleState(boolToInt(this.planeCPAO.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "4":
                        this.planeTravelInfo.toggleActive();
                        Console.WriteLine("Travel Info Module toggled to ");
                        colouredModuleState(boolToInt(this.planeTravelInfo.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "5":
                        this.planeExtTemp.toggleActive();
                        Console.WriteLine("Exterior Temperature Module toggled to ");
                        colouredModuleState(boolToInt(this.planeExtTemp.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "6":
                        this.planeLiquidLevel.toggleActive();
                        Console.WriteLine("Liquid Level Module toggled to ");
                        colouredModuleState(boolToInt(this.planeLiquidLevel.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "7":
                        this.planeFuelControl.toggleActive();
                        Console.WriteLine("Fuel Control Module toggled to ");
                        colouredModuleState(boolToInt(this.planeFuelControl.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "8":
                        this.planeSpeed.toggleActive();
                        Console.WriteLine("Plane Speed Module toggled to ");
                        colouredModuleState(boolToInt(this.planeSpeed.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "9":
                        this.planeIntTemp.toggleActive();
                        Console.WriteLine("Interior Temperature Module toggled to ");
                        colouredModuleState(boolToInt(this.planeIntTemp.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "10":
                        this.planeAltitude.toggleActive();
                        Console.WriteLine("Altitude Module toggled to ");
                        colouredModuleState(boolToInt(this.planeAltitude.getActivity()));
                        Console.WriteLine("\n");
                        break;

                    case "11":
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
                    string loopOption = Console.ReadLine();
                    if ("y" == loopOption)
                    {
                        continueLoop = false;
                        overrideLoop = true;
                    }
                    else if ("n" == loopOption)
                    {
                        continueLoop = false;
                        overrideLoop = false;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                    }
                }
            }

            //unsure what false case to pass, should return false if they miss the exit option and it reaches this point??
            return false;
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

            bool toggleLoop = true;
            while (toggleLoop)
            {
                int falseCount = 0;
                for(int i = 0; i < moduleArray.Length; i++)
                {
                    if (!moduleArray[i].getActivity())
                    {
                        falseCount++;
                    }
                }
                if (11 == falseCount)
                {
                    this.autoPilotState = 0;
                }
                else if (0 == falseCount)
                {
                    this.autoPilotState = 1;
                }
                else
                {
                    this.autoPilotState = 2;
                }

                Console.WriteLine("AutoPilot state = ");
                colouredModuleState(this.autoPilotState);
                Console.WriteLine("\nToggle Auto Pilot to true or false? [t/f]:");
                string inputOption = Console.ReadLine();

                if ("t" == inputOption)
                {
                    this.autoPilotState = 1;
                    toggleLoop = false;
                }
                else if ("f" == inputOption)
                {
                    this.autoPilotState = 0;
                    //do nothing since they do not want to change it
                    toggleLoop = false;
                }
                else
                {
                    Console.WriteLine("Unknown Input Please Try Again (inputs are 't' for true or 'f' for false\n");
                }
            }

            //check if module = true and set to off
            for (int i = 0; i < moduleArray.Length; i++)
            {
                if (this.autoPilotState != boolToInt(moduleArray[i].getActivity()))
                {
                    moduleArray[i].toggleActive();
                }
            }

            //check that they were set correctly
            for (int i = 0; i < moduleArray.Length; i++)
            {
                if (this.autoPilotState != boolToInt(moduleArray[i].getActivity()))
                {
                    return false;
                }
            }

            return true;
        }
    }
}