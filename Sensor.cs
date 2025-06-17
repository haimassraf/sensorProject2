using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensorProject2
{
    internal class Sensor
    {
        public interface ISensor
        {
            void Activate();
            string GetName();
        }
        public class Termal : ISensor
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
        public class Movement : ISensor
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
}
