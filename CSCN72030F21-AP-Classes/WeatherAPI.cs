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
            } else if (rainStatus == -1) {
                //below
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
            } else if (humidityStatus == -1) {
                //below
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
            } else if (uvStatus == -1) {
                //below
            }

        }



        //This method should realistically never be called
        public override bool modify(string inputValue)
        {
            return true;
        }
    }
}
