using System;

namespace Sensor
{
    public interface ISensor
    {
        void Activate();
        string GetName();
    }

    public class Termal : ISensor
    {
        private string Name;
        public Termal(string name) => Name = name;
        public string GetName() => this.Name;
        public void Activate()
        {
            Console.WriteLine("The Thermal sensor is activated.");
        }
    }

    public class Movement : ISensor
    {
        private string Name;
        public Movement(string name) => Name = name;
        public string GetName() => this.Name;
        public void Activate()
        {
            Console.WriteLine("The Movement sensor is activated.");
        }
    }
}