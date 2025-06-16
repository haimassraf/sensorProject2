using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensorProject2
{
    internal class IranianAgent
    {
        private string name;
        private List<Sensor> weaknesses;
        private List<Sensor> attachSensor;

        public string GetName() => this.name;
        public List<Sensor> GetWeaknesses() => this.weaknesses;
        public List<Sensor> GetAttachSensor() => this.attachSensor;

        public void AttachSensor(Sensor attachedSensor)
        {
            if (this.attachSensor.Count < 2)
            {
                this.attachSensor.Add(attachedSensor);
                attachedSensor.Active();
            }
            else
            {
                Console.WriteLine("You already attach 2 sensors.");
            }
        }

        public int CheckSensors()
        {
            int currectSensors = 0;
            if (weaknesses.Count == 2 && attachSensor.Count == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (this.weaknesses[i] == this.attachSensor[i])
                    {
                        currectSensors++;
                    }
                }
            }
            else
            {
                Console.WriteLine("You need to enter 2 attached sensor first.");
            }
            return currectSensors;
        }

        public bool IsExposed() => CheckSensors() == 2;

        public void ResetSensors()
        {
            this.attachSensor = new List<Sensor>();
            Console.WriteLine("The attached sensors reset.");
        }

        public IranianAgent(string name, List<Sensor> weaknesses)
        {
            this.name = name;
            this.weaknesses = weaknesses;
        }
    }
}
