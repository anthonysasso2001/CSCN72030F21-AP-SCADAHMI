using System;
using System.IO;
using System.Text;
using System.Linq;
namespace CSCN72030F21_AP_Classes
{
    public abstract class HardwareIO
    {
        //Variables
        private string fileName;
        private bool isModifiable;
        private bool isActive;
        private int position;

        //Constructor
        public HardwareIO(string inputFileName, bool inputModifiability)
        {
            this.fileName = inputFileName;
            this.isModifiable = inputModifiability;
            this.isActive = true;
            this.position = 1;
        }

        //file IO stuff
        public string getFileName()
        {
            return this.fileName;
        }

        public bool setFileName(string inputFileName)
        {
            this.fileName = inputFileName;
            if(this.fileName == inputFileName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //File input that overwrites entire file
        public bool fileUpdate(string inputValue)
        {
            File.WriteAllText(this.fileName, inputValue);
            return true;
        }

        public string fileGet(int position)
        {
            string outputString = "";
            try
            {
                outputString = File.ReadLines(this.fileName).Skip(position - 1).Take(1).First();
            }
            catch (System.InvalidOperationException E)
            {
                //Console.WriteLine("Line {0} doesn't exist", position);
                outputString = ("LINE_ERROR "+E.Message);    //if line doesn't exist...
            }
            return outputString;
        }

        //abstract functions to be overrided
        public abstract bool display(int inputTime);

        public abstract bool modify(string inputValue);

        //functions for activity
        public void toggleActive()
        {
            if (true == this.isActive)
            {
                this.isActive = false;
            }
            else
            {
                this.isActive = true;
            }
        }

        public bool getActivity()
        {
            return this.isActive;
        }

        //functions for modifiability
        public bool getModifiability()
        {
            return this.isModifiable;
        }

        public bool setModifiability(bool newModifiability)
        {
            this.isModifiable = newModifiability;
            if (this.isModifiable == newModifiability)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //functions for position
        public int getPosition()
        {
            return this.position;
        }
        public void setLastPosition(int newPosition)
        {
            this.position = newPosition;
        }
    }
}
