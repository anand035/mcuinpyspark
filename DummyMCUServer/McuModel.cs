// Import necessary namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyMCUServer
{
    // Class representing the MCU model
    public class McuModel
    {
        // Dictionary to store hero names and their powers, case-insensitive
        private Dictionary<string, string> _data = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        // Constructor to initialize the model with predefined data
        public McuModel()
        {
            Console.WriteLine("Loading model");
            // Adding hero names and their corresponding powers to the dictionary
            _data.Add("Hulk", "Smash");
            _data.Add("Thor", "Hammer");
            _data.Add("CaptainAmerica", "Shield");
            _data.Add("Ironman", "Suit");
            _data.Add("HawkEye", "Arrow");
            _data.Add("SpiderMan", "Web");
            _data.Add("Groot", "I am Groot !!");
        }

        // Method to get the power of a given hero
        public string GetPower(string hero)
        {
            // Check if the hero exists in the dictionary
            if(_data.ContainsKey(hero))
            {
                return _data[hero]; // Return the power if found
            }
            else
            {
                return "Not found !!"; // Return "Not found" if the hero is not in the dictionary
            }
        }
    }
}
