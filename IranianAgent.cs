using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensorProject2
{
    abstract class IranianAgent
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public List<Sensor> AttachedSensors;
        public Dictionary<Sensor, bool> Weaknesses;

        public void AttachSensor(Sensor sensor)
        {
            AttachedSensors.Add(sensor);
            Console.WriteLine($"Sensor {sensor.GetName()} attached.");
        }
        public void Hit()
        {
            foreach (Sensor attachedSensor in AttachedSensors)
            {
                if (Weaknesses.ContainsKey(attachedSensor) && !Weaknesses[attachedSensor])
                {
                    Weaknesses[attachedSensor] = true;
                }
            }
        }

        public int CountOfHit()
        {
            int count = 0;
            foreach (KeyValuePair<Sensor, bool> weaknessesSensors in Weaknesses)
            {
                if (weaknessesSensors.Value)
                {
                    count++;
                }
            }
            return count;
        }

        public bool IsExposed()
        {
            return !Weaknesses.ContainsValue(false);
        }
    }

    public class JuniorAgent : IranianAgent
    {
        public JuniorAgent(string name, string rank)
        {
            Name = name;
            Rank = rank;
        }
    }

}
