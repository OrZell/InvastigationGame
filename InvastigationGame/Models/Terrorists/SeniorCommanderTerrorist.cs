using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Models.Terrorists
{
    public class SeniorCommanderTerrorist : Terrorist
    {
        public int AttackCounter;

        public SeniorCommanderTerrorist() : base("senior commander")
        {
            this.AttackCounter = 0;
        }

        public void Attack()
        {
            if (this.AttackCounter < 2)
            {
                this.AttackCounter++;
            }
            else
            {
                this.RemoveActive(OrganizeActiveSensor());
                this.AttackCounter = 0;
            }
        }

        public List<Sensor> OrganizeActiveSensor()
        {
            List<Sensor> ActiveSensors = new List<Sensor>();

            foreach (Sensor sensor in this.WeaknesSensors)
            {
                if (sensor.Active)
                {
                    ActiveSensors.Add(sensor);
                }
            }
            return ActiveSensors;
        }

        public void RemoveActive(List<Sensor> ActiveSensors, int HowMany = 2)
        {
            Random Rand = new Random();
            int minOption = int.Min(HowMany, ActiveSensors.Count);

            for (int i = 0; i < minOption; i++)
            {
                Sensor sen = ActiveSensors.ElementAt(Rand.Next(ActiveSensors.Count));
                sen.Active = false;
                ActiveSensors.Remove(sen);
            }

        }
    }
}
