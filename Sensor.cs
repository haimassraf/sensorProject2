using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensorProject2
{
    internal class Sensor
    {
        private string name;
        public string GetName() => this.name;
        public Sensor(string name)
        {
            this.name = name;
        }
        public void Active()
        {
            Console.WriteLine($"Sensor {name} is in active.");
        }
    }
}
