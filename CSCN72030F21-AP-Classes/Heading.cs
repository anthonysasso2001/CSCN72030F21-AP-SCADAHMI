using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Eric Fischer

namespace CSCN72030F21_AP_Classes {
    public class Heading : HardwareIO {
        private double currentHeading;
        public Heading(string inputFileName) : base(inputFileName, true) {
            this.currentHeading = 0;
        }

        public string loadData(int position) {
            string dataString = fileGet(position);
            return dataString;
        }

        public override bool display(int inputTime) {
            
            for(int i = 1; i < inputTime; i++) {




            }


            return true;
        }

        public override bool modify(string inputValue) {
            
            return true;
        }
    }
}
