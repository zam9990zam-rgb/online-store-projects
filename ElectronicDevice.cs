using System;

namespace IPG_OOP_Project.Core
{
    public delegate void StatusChangeHandler(string deviceName, bool newStatus);

    public class ElectronicDevice : AbstractBase 
    {
        private string name;
        private string model;
        private bool ison;
        private double power;

        public event StatusChangeHandler OnStatusChanged;

        public ElectronicDevice(string deviceName, string modelNumber, double powerConsumptionWatts)
        {
            name = deviceName;
            model = modelNumber;
            ison = false; 
            power = powerConsumptionWatts;
        }

        public string DeviceName
        {
            get { return name; }
        }

        public bool IsPoweredOn
        {
            get { return ison; }
        }

        public void TurnOn()
        {
            if (!ison)
            {
                ison = true;
                Console.WriteLine(name + " is turning ON.");
                OnStatusChanged?.Invoke(name, ison);
            }
            else
            {
                Console.WriteLine(name + " is already ON.");
            }
        }

        public void TurnOff()
        {
            if (ison)
            {
                ison = false;
                Console.WriteLine(name + " is turning OFF.");
                OnStatusChanged?.Invoke(name, ison);
            }
            else
            {
                Console.WriteLine(name + " is already OFF.");
            }
        }

        public override void DisplayDetails()
        {
            Console.WriteLine("Details:");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Status: " + (ison ? "ON" : "OFF"));
            Console.WriteLine("Power: " + power + "W");
        }
    }
}
