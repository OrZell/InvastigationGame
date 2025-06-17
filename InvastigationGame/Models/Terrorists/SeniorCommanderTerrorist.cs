using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Models.Terrorists
{
    public class SeniorCommanderTerrorist : Terrorist
    {
        public int AttackCounter;
        public int MaxAttackCounter;

        public SeniorCommanderTerrorist() : base("senior commander")
        {
            this._Capacity = 6;
            this.AttackCounter = 0;
            this.MaxAttackCounter = 3;
        }

        public void Attack()
        {
            if (this.AttackCounter < this.MaxAttackCounter-1)
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
