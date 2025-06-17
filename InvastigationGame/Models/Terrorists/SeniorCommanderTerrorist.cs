using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Models.Terrorists
{
    public class SeniorCommanderTerrorist : Terrorist
    {
        public int AttackCounter = 0;

        public SeniorCommanderTerrorist() : base("senior commander")
        {

        }

        public void Attack()
        {
            if (this.AttackCounter < 2)
            {
                this.AttackCounter++;
            }
            else
            {
                this.AttackCounter = 0;
                this.RemoveActive();
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

        public void RemoveActive(List<Sensor> ActiveSensors, int HowMany)
        {
            Random Rand = new Random();
            int minOption = int.Min(HowMany, )



        }
    }
}
