using InvastigationGame.Generators;
using InvastigationGame.Models.Sensors;
using InvastigationGame.Models.Terrorists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvastigationGame
{
    public class Menu
    {
        private Terrorist Terrorist;
        public Menu()
        {
            this.Terrorist = GeneratorTerrorist.GeneartePrivateTerrorist();
        }

        public void MainMenu()
        {
            bool sign = true;
            do
            {
                Console.WriteLine("Guess The Sensor:\n" +
                  "1. Movement\n" +
                  "2. Lighting\n" +
                  "3. Selolar");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        sign = Flow("movement");
                        break;

                    case "2":
                        sign = Flow("lighting");
                        break;

                    case "3":
                        sign = Flow("selolar");
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
            while (sign);
        }

        public void Guess(string type)
        {
            foreach (Sensor sensor in this.Terrorist.WeaknesSensors)
            {
                if (!sensor.Activate && sensor.Type == type)
                {
                    this.Terrorist.Touched.Add(type);
                    sensor.Active();
                    break;
                }
            }
        }

        public int[] CheckLens()
        {
            int[] lens = new int[2];
            lens[0] = this.Terrorist.Touched.Count;
            lens[1] = this.Terrorist.WeaknesSensors.Count;
            return lens;
        }

        public bool CheckIfTouched(int[] nums)
        {
            bool sign = true;
            if (nums[0] == nums[1])
            {
                sign = false;
            }
            return sign;
        }

        public bool Flow(string type)
        {
            int[] nums = new int[2];

            Guess(type);
            nums = CheckLens();
            Console.WriteLine($"You got {nums[0]} / {nums[1]}");
            return CheckIfTouched(nums);
        }
    }
}
