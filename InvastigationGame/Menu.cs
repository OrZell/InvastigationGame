using InvastigationGame.Generators;
using InvastigationGame.Models.Sensors;
using InvastigationGame.Models.Terrorists;

namespace InvastigationGame
{
    public class Menu
    {
        private Terrorist Terrorist;
        private bool AttackableTerrorist;
        public Menu()
        {
            this.Terrorist = GeneratorTerrorist.GenerateRandomTerrorist();
            if (ProgramStaticData.StaticData.TypesAttackbleTerrorist.Contains(this.Terrorist.Type))
            {
                this.AttackableTerrorist = true;
            }
            else
            {
                this.AttackableTerrorist = false;
            }
        }

        public void MainMenu()
        {
            bool sign = true;
            do
            {
                Console.WriteLine("Guess The Sensor:\n" +
                  "1. Movement\n" +
                  "2. Lighting\n" +
                  "3. Selolar\n" +
                  "4. Pulse\n" +
                  "5. Magnet\n" +
                  "6. Termal\n" +
                  "7. Signal\n" +
                  "8. Exit\n"
                  );
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

                    case "4":
                        sign = Flow("pulse");
                        break;

                    case "5":
                        sign = Flow("magnet");
                        break;

                    case "6":
                        sign = Flow("termal");
                        break;

                    case "7":
                        sign = Flow("signal");
                        break;

                    case "8":
                        sign = false;
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
            while (sign);
        }
        public bool Flow(string type)
        {
            int[] nums = new int[2];

            Guess(type);
            UpdateTheTouched();
            nums = CheckLens();
            Console.WriteLine($"You got {nums[0]} / {nums[1]}");
            if (this.AttackableTerrorist)
            {
                IncreaseTheAttackCounter();
            }
            return CheckIfTouched(nums);
        }

        public void Guess(string type)
        {
            foreach (Sensor sensor in this.Terrorist.WeaknesSensors)
            {
                if (sensor.Type == type && !sensor.Active)
                {
                    sensor.Activate();
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

        public void UpdateTheTouched()
        {
            this.Terrorist.Touched.Clear();
            foreach (Sensor sensor in this.Terrorist.WeaknesSensors)
            {
                if (sensor.Active == true)
                {
                    this.Terrorist.Touched.Add(sensor);
                }
            }
        }

        private void UpdateThePulseSensors()
        {
            foreach (Sensor sensor in this.Terrorist.WeaknesSensors)
            {
                if (sensor is PulseSensor && sensor.Active)
                {
                    PulseSensor psensor = (PulseSensor)sensor;
                    psensor.Countering();
                    break;
                }
            }
        }

        private void IncreaseTheAttackCounter()
        {
            if (this.AttackableTerrorist)
            {
                SquadLeaderTerrorist terrorist = (SquadLeaderTerrorist)this.Terrorist;
                terrorist.Attack();
            }
        }
    }
}
