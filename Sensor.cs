using System;

namespace sensorProject2
{
    internal class Sensor
    {
        public interface ISensor
        {
            void Activate();
            string GetName();
        }
    }
    public class Termal : Sensor.ISensor
    {
        private string Name;
        public string GetName() => this.Name;
        public void Activate()
        {
            Console.WriteLine("The sensor Termal is activate.");
        }

        public Termal(string name)
        {
            Name = name;
        }
    }
    public class Movement : Sensor.ISensor
    {
        public string Name;
        public string GetName() => this.Name;
        public void Activate()
        {
            Console.WriteLine("The sensor Movment is activate.");
        }
        public Movement(string name)
        {
            Name = name;
        }
    }
}
