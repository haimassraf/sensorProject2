using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensorProject2
{
    internal class GameManager
    {
        private IranianAgent agent;
        private string[] sensorTypes = { "Thermal", "Motion" };
        private Random random = new Random();

        public void StartGame()
        {
            Console.WriteLine("Welcome!");

            List<Sensor> weaknesses = new List<Sensor>();
            for (int i = 0; i < 2; i++)
            {
                Sensor newSensor = new Sensor(sensorTypes[random.Next(sensorTypes.Length)]);
                weaknesses.Add(newSensor);
            }

            agent = new IranianAgent("Muhamad", weaknesses);

            int turn = 1;

            while (!agent.IsExposed())
            {
                Console.WriteLine($"\nTurn {turn}: Choose 2 sensors to attach:");

                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine($"\nSensor #{i + 1}:");
                    for (int j = 0; j < sensorTypes.Length; j++)
                    {
                        Console.WriteLine($"{j + 1}. {sensorTypes[j]}");
                    }

                    string input = Console.ReadLine();
                    int choice;
                    if (int.TryParse(input, out choice) && choice >= 1 && choice <= sensorTypes.Length)
                    {
                        string chosenSensor = sensorTypes[choice - 1];
                        Sensor sensor = new Sensor(chosenSensor);
                        agent.AttachSensor(sensor);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again.");
                        i--;
                    }
                }

                int correct = agent.CheckSensors();
                Console.WriteLine($"Feedback: {correct}/2 sensors are correct.");

                if (!agent.IsExposed())
                {
                    Console.WriteLine("Not all correct. Try again.");
                    agent.ResetSensors();
                }

                turn++;
            }

            Console.WriteLine("\nAgent exposed! Well done.");
        }
    }
}
