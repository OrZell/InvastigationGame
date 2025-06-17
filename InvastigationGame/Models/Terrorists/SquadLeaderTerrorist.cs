using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Models.Terrorists
{
    public class SquadLeaderTerrorist : Terrorist
    {
        public int AttackCounter;
        public int MaxAttackCounter;
        public SquadLeaderTerrorist() : base("squad leader")
        {
            this._Capacity = 4;
            this.AttackCounter = 0;
            this.MaxAttackCounter = 3;
        }

        public void Attack()
        {
            if (AttackCounter < this.MaxAttackCounter-1)
            {
                this.AttackCounter++;
            }
            else
            {
                RemoveActive(OrganizeActiveSensors());
                this.AttackCounter = 0;
            }
        }


        public List<Sensor> OrganizeActiveSensors()
        {
            List<Sensor> ActiveSensors = new List<Sensor>();

            foreach (Sensor sensor in WeaknesSensors)
            {
                if (sensor.Active)
                {
                    ActiveSensors.Add(sensor);
                }
            }
            return ActiveSensors;
        }
        public void RemoveActive(List<Sensor> ActiveSensors, int HowMany=1)
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
