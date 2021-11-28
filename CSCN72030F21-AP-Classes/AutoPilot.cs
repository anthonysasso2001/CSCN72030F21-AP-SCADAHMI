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
                //legacy from commented out continue loop, will deleted when / if it is removed...
                //bool returnFromSub = false;

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
                        //legacy from commented out continue loop, will deleted when / if it is removed...
                        //returnFromSub = true;
                        break;

                    case "2":
                        this.ControlMenu();
                        //legacy from commented out continue loop, will deleted when / if it is removed...
                        //returnFromSub = true;
                        break;

                    case "3":
                        this.manualOverrides();
                        //legacy from commented out continue loop, will deleted when / if it is removed...
                        //returnFromSub = true;
                        break;

                    case "4":
                        this.toggleAutoPilot();
                        //legacy from commented out continue loop, will deleted when / if it is removed...
                        //returnFromSub = true;
                        break;

                    default:
                        Console.WriteLine("Error, Unknown Input\n Please try Again\n");
                        break;
                }

                /*
                 * Keeping this in case we need the loop outline, but serves no functional purpose so commented out...
                 * Will be likely deleted before v2 unless required / utilized
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
                */
            }
        }

        //Sensor Menu & Options
        private void SensorMenu()
        {
            bool sensorLoop = true;
            while (sensorLoop)
            {

                Console.WriteLine("Please select a sensor module to access (by number):\n");

                Console.WriteLine("0. Exit Sensor Menu & Return to Main Menu\n");

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
                            Console.WriteLine("Are you sure you want to return to the main menu?\n[y/n]: ");
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

                //May be removed for same reason as main menu, technically redundant...
                //bool continueLoop = true;
                //while (continueLoop) {
                //    Console.WriteLine("Would you like to continue?\n[y/n]:");
                //    string loopOption = Console.ReadLine();
                //    if ("y" == loopOption)
                //    {
                //        continueLoop = false;
                //        sensorLoop = true;
                //    }
                //    else if ("n" == loopOption)
                //    {
                //        continueLoop = false;
                //        sensorLoop = false;
                //        return;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                //    }
                //}
            }
        }
        private bool WeatherAPISensorOption()
        {
            //Borrowing menu format from Eazaz
            bool trueLoop = true;
            while (trueLoop) {
                int secondsValue = 0;

                Console.WriteLine("Please enter the amount of time you would like to monitor the WeatherAPI Readings or q to go back: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out secondsValue) && secondsValue > 0) {
                    bool weatherState = this.showInfo(this.weather, secondsValue);
                    return weatherState;
                } else if (input == "q") {
                    return false;
                } else {
                    Console.WriteLine("The input was not in the correct format.");
                }
            }

            return true;
        }
        private bool ForceAndVibrationSensorOption()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
               
                int value = 0;

                Console.WriteLine("Please enter the amount of time you would like to monitor the Force and Vibration Readings or q to go back: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out value) && value > 0)
                {
                    bool FAVState = this.showInfo(this.planeFAV, value);
                    return FAVState;
                    
                }
                else if (input == "q")
                {
                    
                    return false;
                }
                else
                {
                    Console.WriteLine("The input was not in the correct format.");

                }
            }

            return true;
        }
        private bool CabinPressureAndOxygenSensorOption()
        {
            Console.WriteLine("Cabin Pressure & Oxygen Menu");
            Console.WriteLine("Select how long to review the sensor");
            Console.Write(": ");
            string userInput = Console.ReadLine();
            int inputTime = Convert.ToInt32(userInput);
            bool CPAOState = this.showInfo(this.planeCPAO, inputTime);
            return CPAOState;
        }
        private bool TravelInfoSensorOption()
        {
            bool loopStatus = true;
            while (loopStatus)
            {
                int inputTimeConvert = 0;
                Console.WriteLine("Please input the amount of seconds you would like to view the data for Travel Information for, or press q to go back to the previous menu:");
                string inputTime = Console.ReadLine();
                if (int.TryParse(inputTime, out inputTimeConvert) && inputTimeConvert > 0)
                {
                    bool travelInfoState = this.showInfo(this.planeTravelInfo, inputTimeConvert);
                    return travelInfoState;
                }
                else if(inputTime == "q")
                {
                    Console.WriteLine("Returning to the previous menu");
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again or enter 'q' to return to the menu");
                }
            }
            
            return true; 
        }
        private bool ExteriorTempSensorOption()
        {
            bool repeat = true;

            while (repeat)
            {
                int inputTime = 0;
                Console.WriteLine("Enter the total time (seconds) that you want to view the exterior temperature, or press q to return to previous menu:");
                String userInput = Console.ReadLine();
                if (userInput == "q")
                    return false;
                else
                    Int32.TryParse(userInput, out inputTime);

                
                if (inputTime < 1)
                {
                    Console.WriteLine("Invalid viewing time!");
                    continue;
                }
                else
                {
                    this.showInfo(this.planeExtTemp, inputTime);
                    repeat = false;
                }
            }
            return true;
        }
        private bool LiquidLevelSensorOption()
        {
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine("Enter the total time (seconds) that you want to view the liquid level, or press q to return to previous menu:");
                String userInput = Console.ReadLine();
                int inputTime = 0;
                Int32.TryParse(userInput,out inputTime);

                if (userInput == "q")
                    return false;
                else if (inputTime < 1)
                {
                    Console.WriteLine("Invalid viewing time!");
                    continue;
                }
                else
                {
                    this.showInfo(this.planeLiquidLevel, inputTime);
                    repeat = false;
                }
            }
            return true;
        }

        //Control Menu & Options
        private void ControlMenu()
        {
            bool controlLoop = true;
            while (controlLoop)
            {
                Console.WriteLine("Please select a control module to access (by number):\n");

                Console.WriteLine("0. Exit Control Menu & Return to Main Menu\n");

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
                            Console.WriteLine("Are you sure you want to return to the main menu?\n[y/n]: ");
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

                //May be removed for same reason as main menu, technically redundant...
                //bool continueLoop = true;
                //while (continueLoop)
                //{
                //    Console.WriteLine("Would you like to continue?\n[y/n]:");
                //    string loopOption = Console.ReadLine();
                //    if ("y" == loopOption)
                //    {
                //        continueLoop = false;
                //        controlLoop = true;
                //    }
                //    else if ("n" == loopOption)
                //    {
                //        continueLoop = false;
                //        controlLoop = false;
                //        return;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                //    }
                //}
            }
        }
        private bool FuelControlControlOption()
        {
            bool loopStatus = true;
            while(loopStatus)
            {
                int inputConvert = 0;

                Console.WriteLine("Fuel Control menu options:\n");
                Console.WriteLine("0. Go back to previous menu");
                Console.WriteLine("1. Display current fuel readings");
                Console.WriteLine("2. Modify fuel levels");

                string input = Console.ReadLine();

                if (int.TryParse(input, out inputConvert) && inputConvert == 1)
                {
                    bool innerStatus = true;
                    while (innerStatus)
                    {
                        int inputTimeConvert = 0;
                        Console.WriteLine("Please input the number of seconds you would like to view the fuel readings for, or press q to go back to the previous menu:");
                        string inputTime = Console.ReadLine();
                        if (int.TryParse(inputTime, out inputTimeConvert) && inputTimeConvert > 0)
                        {
                            bool fuelState = this.showInfo(this.planeFuelControl, inputTimeConvert);
                            return fuelState;
                        }
                        else if (inputTime == "q")
                        {
                            Console.WriteLine("Returning to the previous menu");
                            return false;
                            //continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please try again or enter 'q' to return to the previous menu");
                        }
                    }
                    continue;
                }
                else if(int.TryParse(input, out inputConvert) && inputConvert == 2)
                {

                    bool innerStatus = true;
                    int fuelCheck = 0;
                    while (innerStatus)
                    {
                        Console.WriteLine("Please enter the amount of fuel % to dump between 5 and 20 or enter 'q' to go back ");
                        string fuelInput = Console.ReadLine();

                        if(int.TryParse(fuelInput, out fuelCheck) && fuelCheck >= 5 && fuelCheck <= 20)
                        {
                            bool fuelState = this.changeInfo(this.planeFuelControl, fuelInput);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("The fuel has been successfully dropped.");
                            Console.ForegroundColor = ConsoleColor.Gray;

                            return fuelState;
                        }
                        else if(fuelInput == "q")
                        {
                            Console.WriteLine("Returning to the previous menu");
                            innerStatus = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please try again or enter 'q' to return to the previous menu");
                        }
                    }
                }
                else if (input == "0")
                {
                    Console.WriteLine("Returning to the previous menu");
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
            return true;
        }
        private bool AirSpeedControlOption()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                int value = 0;

                Console.WriteLine("Please enter 1 to display the speed OR press 2 to modify the speed OR press q to go back: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value == 1)
                {
                    bool keepgoing = true;
                    while (keepgoing)
                    {
                        Console.WriteLine("Please enter the amount of time you would like to monitor the AirSpeed Readings OR q to go back: ");
                        string displayInput = Console.ReadLine();

                        if (int.TryParse(displayInput, out value) && value > 0)
                        {
                            bool speedState = this.showInfo(this.planeSpeed, value);
                            return speedState;
                        }
                        else if (displayInput == "q")
                        {
                            keepgoing = false;
                        }
                        else
                        {
                            Console.WriteLine("The input was not in the correct format.");
                        }
                    }
                    continue;

                }
                else if (int.TryParse(input, out value) && value == 2)
                {
                    bool keepgoing = true;
                    while (keepgoing)
                    {
                        Console.WriteLine("Please enter the AirSpeed you would like to change to OR q to go back: ");
                        string displayInput = Console.ReadLine();

                        if (int.TryParse(displayInput, out value) && value > 0 && value < 1200)
                        {
                            string something = Convert.ToString(value);
                            bool speedState = this.changeInfo(this.planeSpeed, something);
                            if (speedState)
                            {
                                Console.WriteLine("Speed was succesfully changed.");
                            }
                            return speedState;
                        }
                        else if (displayInput == "q")
                        {
                            keepgoing = false;
                        }
                        else
                        {
                            Console.WriteLine("The input was not in the correct format.");
                        }
                    }
                }
                else if (input == "q")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("The input was not in the correct format.");
                }


            }

            return true;
        }
        private bool CabinTempControlOption()
        {
            Console.WriteLine("Select one of the option below:");
            Console.WriteLine("1. View temperature");
            Console.WriteLine("2. Modify temperature");
            Console.WriteLine("3. Return to previous menu");
            string inputOption = Console.ReadLine();
            int inputTime;
            bool repeat = true;

            if (inputOption == "1")
            {
                while (repeat)
                {
                    Console.WriteLine("Enter the total time(seconds) that you want to view the liquid level:");
                    inputTime = Int32.Parse(Console.ReadLine());
                    if (inputTime < 1)
                    {
                        Console.WriteLine("Invalid time");
                    }
                    else
                    {
                        this. showInfo(this.planeIntTemp,inputTime);
                        repeat = false;
                    }
                }
            }
            else if (inputOption == "2")
            {
                Console.WriteLine("Enter a temperature (Celsius) that you want to set for the cabin (Between 16 and 30 degrees is recommended):");
                string inputValue = Console.ReadLine();
                this.changeInfo(this.planeIntTemp, inputValue);
            }
            else if (inputOption == "3")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                return false;
            }
            return true;
        }
        private bool AltitudeControlOption()
        {
            Console.WriteLine("Altitude Menu");

            bool continueLoop = true;
            bool AltitudeState = true;
            while (continueLoop)
            {
                Console.Write("Would you like to display / modify the data?\n[d/m]: ");
                string loopOption = Console.ReadLine();
                if ("d" == loopOption)
                {
                    continueLoop = false;
                    Console.WriteLine("Select how long to review the sensor");
                    Console.Write(": ");
                    string userInput = Console.ReadLine();
                    int inputTime = Convert.ToInt32(userInput);
                    AltitudeState = this.showInfo(this.planeAltitude, inputTime);
                }
                else if ("m" == loopOption)
                {
                    continueLoop = false;
                    bool modifyLoop = true;
                    while (modifyLoop)
                    {
                        Console.WriteLine("Select the new altitude for the plane");
                        Console.Write("[28871.39 - 45931.759]: ");
                        string userInput = Console.ReadLine();
                        if (double.TryParse(userInput, out double d) && !Double.IsNaN(d) && !Double.IsInfinity(d))
                        {
                            modifyLoop = false;
                            AltitudeState = this.changeInfo(this.planeAltitude, userInput);
                        }
                        else
                        {
                            Console.WriteLine("Unknown Input Please Try Again (inputs are distances between 28871.39 - 45931.759\n");
                        }
                    }                    
                }
                else
                {
                    Console.WriteLine("Unknown Input Please Try Again (inputs are 'd' for display or 'm' for modify\n");
                }
            }
            return AltitudeState;
        }
        private bool HeadingControlOption()
        {
            //Borrowing menu format from Eazaz
            
            bool mainLoop = true;
            while (mainLoop) {
                int secondsValue = 0;
                double inputHeading = 0;
                int inputValue = 0;

                Console.WriteLine("Please enter 1 to display the heading OR press 2 to modify the heading OR press q to go back: ");
                string input = Console.ReadLine();

                //Display menu
                if (int.TryParse(input, out inputValue) && inputValue == 1) {
                    bool displayLoop = true;
                    while (displayLoop) {
                        Console.WriteLine("Please enter the amount of time you would like to monitor the Heading Readings OR q to go back: ");
                        string displayInput = Console.ReadLine();

                        if (int.TryParse(displayInput, out secondsValue) && secondsValue > 0) {
                            bool headingState = this.showInfo(this.planeHeading, secondsValue);
                            return headingState;
                        } else if (displayInput == "q") {
                            displayLoop = false;
                        } else {
                            Console.WriteLine("The input was not in the correct format.");
                        }
                    }
                    continue;


                //Modify menu
                } else if (int.TryParse(input, out inputValue) && inputValue == 2) {
                    bool modLoop = true;
                    while (modLoop) {
                        Console.WriteLine("Please enter the Heading you would like to change to OR q to go back: ");
                        string displayInput = Console.ReadLine();

                        if (double.TryParse(displayInput, out inputHeading) && inputHeading > 0 && inputHeading < 360) {
                            double headingStep4 = inputHeading + 4;
                            headingStep4 = headingStep4 % 360;
                            double headingStep3 = headingStep4 + 4;
                            headingStep3 = headingStep3 % 360;
                            double headingStep2 = headingStep3 + 4;
                            headingStep2 = headingStep2 % 360;
                            double headingStep1 = headingStep2 + 4;
                            headingStep1 = headingStep1 % 360;

                            string newFinalHeading = Convert.ToString(inputHeading);
                            string newStep4Heading = Convert.ToString(headingStep4);
                            string newStep3Heading = Convert.ToString(headingStep3);
                            string newStep2Heading = Convert.ToString(headingStep2);
                            string newStep1Heading = Convert.ToString(headingStep1);

                            string newHeading = newStep1Heading + '\n' + newStep2Heading + '\n' + newStep3Heading + '\n' + newStep4Heading + '\n' + newFinalHeading;

                            bool headingState = this.changeInfo(this.planeHeading, newHeading);
                            if (headingState) {
                                Console.WriteLine("Heading was succesfully changed.");
                            }
                            return headingState;
                        } else if (displayInput == "q") {
                            modLoop = false;
                        } else {
                            Console.WriteLine("The input was not in the correct range.");
                        }
                    }


                } else if (input == "q") {
                    return false;
                } else {
                    Console.WriteLine("The input was not in the correct format.");
                }
            }



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

                Console.WriteLine("0. Exit Manual Overrides & Return to Main Menu\n");

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
                            Console.WriteLine("Are you sure you want to return to the main menu?\n[y/n]: ");
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

                //May be removed for same reason as main menu, technically redundant...
                //bool continueLoop = true;
                //while (continueLoop)
                //{
                //    Console.WriteLine("Would you like to continue?\n[y/n]:");
                //    string loopOption = Console.ReadLine();
                //    if ("y" == loopOption)
                //    {
                //        continueLoop = false;
                //        overrideLoop = true;
                //    }
                //    else if ("n" == loopOption)
                //    {
                //        continueLoop = false;
                //        overrideLoop = false;
                //        return true;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Unknown Input Please Try Again (inputs are 'y' for yes or 'n' for no\n");
                //    }
                //}
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
                for (int i = 0; i < moduleArray.Length; i++)
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

                Console.Write("AutoPilot state = ");
                colouredModuleState(this.autoPilotState);

                Console.WriteLine(
                    "\nPlease Select How to Toggle the Autopilot (or 0 to exit):\n" +
                    "0. Exit Toggle AutoPilot & Return to Main Menu\n" +
                    "1. Set AutoPilot to all active\n" +
                    "2. Set AutoPilot to all inactive / manual\n");
                Console.Write(":");
                string inputOption = Console.ReadLine();

                //switch case for menu
                switch (inputOption)
                {
                    case "0":
                        bool exitLoop = true;
                        while (exitLoop)
                        {
                            Console.WriteLine("Are you sure you want to return to the main menu?\n[y/n]: ");
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
                        this.autoPilotState = 1;

                        Console.WriteLine("AutoPilot toggled to ");
                        colouredModuleState(this.autoPilotState);
                        Console.WriteLine("\n");
                        break;

                    case "2":
                        this.autoPilotState = 0;

                        Console.WriteLine("AutoPilot toggled to ");
                        colouredModuleState(this.autoPilotState);
                        Console.WriteLine("\n");
                        break;

                    default:
                        Console.WriteLine("Error, Unknown Input\n Please try Again\n");
                        break;
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
            }

            //only let them exit through inputing 0 otherwise it shouldn't exit here...
            return false;
        }
    }
}