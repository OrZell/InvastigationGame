using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Models.Terrorists
{
    public class OrganizationLeaderTerrorist : Terrorist
    {
        public int AttackCounter;
        public int MaxAttackCounter;
        public int WholeResetCounter;
        public int MaxWholeResetCounter;

        public OrganizationLeaderTerrorist() : base("organization leader")
        {
            this._Capacity = 8;
            this.AttackCounter = 0;
            this.MaxAttackCounter = 3;
            this.WholeResetCounter = 0;
            this.MaxWholeResetCounter = 10;
        }

        public void Attack()
        {
            if (this.WholeResetCounter < this.MaxWholeResetCounter-1)
            {
                this.WholeResetCounter++;

                if (this.AttackCounter < this.MaxAttackCounter-1)
                {
                    this.AttackCounter++;
                }
                else
                {
                    RemoveActive(OrganizeActiveSensor());
                    this.AttackCounter = 0;
                }
            }
            else
            {
                TurnOffAll();
                this.WholeResetCounter = 0;
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

        public void RemoveActive(List<Sensor> ActiveSensors, int HowMany = 1)
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

        public void TurnOffAll()
        {
            foreach (Sensor sensor in this.WeaknesSensors)
            {
                sensor.Active = false;
            }
        }
    }
}
