using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Eric Fischer

namespace CSCN72030F21_AP_Classes {
    public class WeatherAPI: HardwareIO {
        private double[] currentWeather;
        public WeatherAPI(string inputFileName): base(inputFileName, false) {
            /* [0]: Chance of rain
             * [1]: Humidity
             * [2]: UV Index
             */
            this.currentWeather = new double[3]{0,0,0};
        }

        public string[] loadData(int position) {
            string dataString = fileGet(position);
            string[] loadedData = dataString.Split(','); //Should seperate the string into Chance of rain, Humidity, and UV Index
            return loadedData;
        }

        public override bool display(int inputTime) {
            
            for(int i = 1; i < inputTime; i++) {

                string[] loadedData = loadData(i);

                currentWeather[0] = Convert.ToDouble(loadedData[0]);
                int rainStatus = rainCheck(currentWeather[0]);
                
                
                currentWeather[1] = Convert.ToDouble(loadedData[1]);
                int humidityStatus = humidityCheck(currentWeather[1]);
                

                currentWeather[2] = Convert.ToDouble(loadedData[2]);
                int UVStatus = UVCheck(currentWeather[2]);



                if (rainStatus == 0 && humidityStatus == 0 && UVStatus == 0) {
                    //Successful print
                    //Rain
                    switch (currentWeather[0]) {
                        default:
                            //Normal levels
                            Console.Write("The Chance of Rain is: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("{0}", currentWeather[0]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }
                    
                    //Humidity
                    switch (currentWeather[1]) {
                        case > 80:
                            //Above optimal
                            Console.Write("The Humidity Percentage is: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}", currentWeather[1]);
                            Console.WriteLine("\tThe Humidity is above the optimal range.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            //Normal levels
                            Console.Write("The Humidity Percentage is: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("{0}", currentWeather[1]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }

                    //UV
                    switch (currentWeather[2]) {
                        case > 10:
                            //Above optimal
                            Console.Write("The UV Index is: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0}", currentWeather[2]);
                            Console.WriteLine("\tThe UV Index is above the optimal range.");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            //Normal levels
                            Console.Write("The UV Index is: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("{0}", currentWeather[2]);
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }

                } else {
                    if (rainStatus != 0) {
                        rainWarning(rainStatus);
                    }
                    
                    if(humidityStatus != 0) {
                        humidityWarning(humidityStatus);
                    }

                    if (UVStatus != 0) {
                        UVWarning(UVStatus);
                    }
                }

            }

            return true;
        }





        private int rainCheck(double rain) {
            if (rain > 100) {
                return 1;
            } else if (rain < 0) {
                return -1;
            }
            return 0;
        }

        private void rainWarning(int rainStatus) {
            if (rainStatus == 1) {
                //above
                Console.WriteLine("The Rain value is above the acceptable range.");
            } else if (rainStatus == -1) {
                //below
                Console.WriteLine("The Rain value is under the acceptable range.");
            }

        }

        private int humidityCheck(double humidity) {
            if (humidity > 100) {
                return 1;
            } else if (humidity < 0) {
                return -1;
            }
            return 0;
        }

        private void humidityWarning(int humidityStatus) {
            if (humidityStatus == 1) {
                //above
                Console.WriteLine("The Humidity value is above the acceptable range.");
            } else if (humidityStatus == -1) {
                //below
                Console.WriteLine("The Humidity value is under the acceptable range.");
            }

        }

        private int UVCheck(double UV) {
            if (UV > 15) {
                return 1;
            } else if (UV < 0) {
                return -1;
            }
            return 0;
        }

        private void UVWarning(int uvStatus) {
            if (uvStatus == 1) {
                //above
                Console.WriteLine("The UV value is above the acceptable range.");
            } else if (uvStatus == -1) {
                //below
                Console.WriteLine("The UV value is under the acceptable range.");
            }

        }



        //This method should realistically never be called
        public override bool modify(string inputValue)
        {
            return true;
        }
    }
}
