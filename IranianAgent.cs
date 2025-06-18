using System;
using System.Collections.Generic;
namespace sensorProject2
{
    abstract class IranianAgent
    {
        public string Name { get; set; }
        public string Rank { get; set; }
        public List<Sensor.ISensor> AttachedSensors;
        public Dictionary<Sensor.ISensor, bool> Weaknesses;

        public void AttachSensor(Sensor.ISensor sensor)
        {
            AttachedSensors.Add(sensor);
            Console.WriteLine($"Sensor {sensor.GetName()} attached.");
        }
        public void Hit()
        {
            foreach (Sensor.ISensor attachedSensor in AttachedSensors)
            {
                if (Weaknesses.ContainsKey(attachedSensor) && !Weaknesses[attachedSensor])
                {
                    Weaknesses[attachedSensor] = true;
                    Console.WriteLine($"The agent hit sucssesfully!");
                }
            }
        }

        public int CountOfHits()
        {
            int count = 0;
            foreach (KeyValuePair<Sensor.ISensor, bool> weaknessesSensors in Weaknesses)
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

        public Dictionary<Sensor.ISensor, bool> GenerateRandomWeaknesses(List<Sensor.ISensor> possibleSensors, int count)
        {
            var rnd = new Random();
            var result = new Dictionary<Sensor.ISensor, bool>();

            var selected = new HashSet<int>();

            while (result.Count < count && result.Count < possibleSensors.Count)
            {
                int index = rnd.Next(possibleSensors.Count);
                if (!selected.Contains(index))
                {
                    selected.Add(index);
                    result[possibleSensors[index]] = false;
                }
            }

            return result;
        }
    }

    public class JuniorAgent : IranianAgent
    {
        public JuniorAgent(string name, string rank)
        {
            Name = name;
            Rank = rank;
            AttachedSensors = new List<Sensor.ISensor>();
            Weaknesses = GenerateRandomWeaknesses(new List<Sensor.ISensor> { new Termal("Termal"), new Movement("Movement") }, 2);
        }
    }

}
