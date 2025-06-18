using System;
using System.Collections.Generic;
using Sensor;
using sensorProject2;

namespace InvestigationGame
{
    public class GameManager
    {
        private IranianAgent agent;
        private List<ISensor> availableSensors;

        public GameManager()
        {
            agent = new JuniorAgent("Reza");

            availableSensors = new List<ISensor>
            {
                new Termal("Thermal"),
                new Movement("Movement")
            };
        }

        public void StartGame()
        {
            Console.WriteLine("Investigation Game Started!");
            Console.WriteLine("Your goal: Expose the Iranian agent by attaching the right sensors.");

            while (!agent.IsExposed())
            {
                ShowSensorMenu();

                int choice = GetSensorChoice();
                if (choice < 1 || choice > availableSensors.Count)
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                ISensor selectedSensor = CloneSensor(availableSensors[choice - 1]);

                selectedSensor.Activate();
                agent.AttachSensor(selectedSensor);
                agent.Hit();

                Console.WriteLine($"Current hits: {agent.CountOfHits()}/{agent.Weaknesses.Count}");
                Console.WriteLine("---------------------------------------");
            }

            Console.WriteLine("The agent is fully exposed! You won.");
        }

        private void ShowSensorMenu()
        {
            Console.WriteLine("\nAvailable Sensors:");
            for (int i = 0; i < availableSensors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableSensors[i].GetName()}");
            }
            Console.Write("Choose a sensor to attach: ");
        }

        private int GetSensorChoice()
        {
            string input = Console.ReadLine();
            return int.TryParse(input, out int choice) ? choice : -1;
        }

        private ISensor CloneSensor(ISensor sensor)
        {
            if (sensor is Termal) return new Termal(sensor.GetName());
            if (sensor is Movement) return new Movement(sensor.GetName());
            throw new Exception("Unknown sensor type.");
        }
    }
}