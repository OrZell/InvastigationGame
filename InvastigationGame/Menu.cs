using InvastigationGame.Generators;
using InvastigationGame.Models.Sensors;
using InvastigationGame.Models.Terrorists;

namespace InvastigationGame
{
    public class Menu
    {
        Terrorist terrorist;
        int DefenceCounter;
        public Menu()
        {

        }

        public string MainMenu(int CurrentLevel, Terrorist terrorist)
        {
            string Exit = "";
            bool sign = true;

            switch (CurrentLevel)
            {
                case 1:
                    this.terrorist = (FootTerrorist)terrorist;
                    break;

                case 2:
                    this.terrorist = (SquadLeaderTerrorist)terrorist;
                    break;

                case 3:
                    this.terrorist = (SeniorCommanderTerrorist)terrorist;
                    break;

                case 4:
                    this.terrorist = (OrganizationLeaderTerrorist)terrorist;
                    break;

                default:
                    break;
            }

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
                        Exit = "Exit";
                        sign = false;
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
            while (sign);
            return Exit;
        }
        public bool Flow(string type)
        {
            int[] nums = new int[2];
            Guess(type);
            UpdateTheTouched();
            nums = CheckLens();
            Console.WriteLine($"You got {nums[0]} / {nums[1]}");

            UpdateThePulseSensors();
            IncreaseTheAttackCounter();

            return CheckIfTouched(nums);
        }

        public void Guess(string type)
        {
            foreach (Sensor sensor in this.terrorist.WeaknesSensors)
            {
                if (sensor.Type == type && !sensor.Active)
                {
                    if (sensor.Type == "magnet")
                    {
                        this.DefenceCounter += 2;
                    }

                    if (sensor.Type == "termal")
                    {
                        Console.WriteLine(UncoverOneSensor());
                    }

                    if (sensor.Type == "signal")
                    {
                        Console.WriteLine($"The Terrorist Type Is: {this.terrorist.Type}");
                    }
                    sensor.Activate();
                    break;
                }
            }
        }

        public int[] CheckLens()
        {
            int[] lens = new int[2];
            lens[0] = this.terrorist.Touched.Count;
            lens[1] = this.terrorist.WeaknesSensors.Count;
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
            this.terrorist.Touched.Clear();
            foreach (Sensor sensor in this.terrorist.WeaknesSensors)
            {
                if (sensor.Active == true)
                {
                    this.terrorist.Touched.Add(sensor);
                }
            }
        }

        private void UpdateThePulseSensors()
        {
            foreach (Sensor sensor in this.terrorist.WeaknesSensors)
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
            if (this.DefenceCounter > 0)
            {
                this.DefenceCounter--;
            }
            else
            {
                this.terrorist.Attack();
            }
        }

        public string UncoverOneSensor()
        {
            List<Sensor> NotActivateSensors = new List<Sensor>();
            Random Rand = new Random();
            string result;

            foreach (Sensor sensor in this.terrorist.WeaknesSensors)
            {
                if (!sensor.Active)
                {
                    NotActivateSensors.Add(sensor);
                }
            }

            if (NotActivateSensors.Count > 0)
            {
                Sensor sen = NotActivateSensors.ElementAt(Rand.Next(NotActivateSensors.Count));
                result = $"The Target Got The Sensor Type: {sen.Type}";
            }
            else
            {
                result = "Not Found Sensor To Discover";
            }
            return result;
        }
    }
}
