using Sensor;
using System.Collections.Generic;
using System;

namespace sensorProject2
{
    public abstract class IranianAgent
    {
        protected string Name;
        protected string Rank;
        public List<ISensor> AttachedSensors { get; set; }
        public Dictionary<string, bool> Weaknesses { get; set; }

        public IranianAgent()
        {
            AttachedSensors = new List<ISensor>();
            Weaknesses = new Dictionary<string, bool>();
        }

        public virtual string GetName() => this.Name;

        public void AttachSensor(ISensor sensor)
        {
            AttachedSensors.Add(sensor);
            Console.WriteLine($"Sensor {sensor.GetName()} attached.");
        }

        public void Hit()
        {
            foreach (ISensor attachedSensor in AttachedSensors)
            {
                if (Weaknesses.ContainsKey(attachedSensor.GetName()) && !Weaknesses[attachedSensor.GetName()])
                {
                    Weaknesses[attachedSensor.GetName()] = true;
                    Console.WriteLine("The agent hit successfully!");
                    //breake?
                }
            }
        }

        public int CountOfHits()
        {
            int count = 0;
            foreach (bool isExposed in Weaknesses.Values)
            {
                if (isExposed)
                {
                    count++;
                }
            }
            return count;
        }

        public bool IsExposed()
        {
            const bool IsExist = false;
            return !Weaknesses.ContainsValue(IsExist);
        }

        protected Dictionary<string, bool> GenerateRandomWeaknesses(List<ISensor> possibleSensors, int count)
        {
            var rnd = new Random();
            var result = new Dictionary<string, bool>();
            var selectedIndices = new List<int>();

            while (result.Count < count && result.Count < possibleSensors.Count)
            {
                int index = rnd.Next(possibleSensors.Count);
                if (!selectedIndices.Contains(index))
                {
                    selectedIndices.Add(index);
                    const bool value = false;
                    result[possibleSensors[index].GetName()] = value;
                }
            }
            return result;
        }
    }

    public class JuniorAgent : IranianAgent
    {
        public JuniorAgent(string name)
        {
            Name = name;
            Rank = "Junior";
            List<ISensor> potentialWeaknesses = new List<ISensor>
            {
                new Termal("Thermal"),
                new Movement("Movement")
            };
            const int NumberOfWeaknesses = 2;
            Weaknesses = GenerateRandomWeaknesses(potentialWeaknesses, NumberOfWeaknesses);
        }
    }
}