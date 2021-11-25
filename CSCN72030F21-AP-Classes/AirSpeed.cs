using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Eazaz Jakda

namespace CSCN72030F21_AP_Classes
{
    public class AirSpeed : HardwareIO
    {
        public AirSpeed(string inputFileName) : base(inputFileName, true)
        {

        }

        public override bool display(int inputTime)
        {
            return true;
        }
        public override bool modify(string inputValue)
        {
            return true;
        }
    }
}
