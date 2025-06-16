using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Models.Terrorists
{
    public class SquadLeaderTerrorist : Terrorist
    {
        public int AttackCounter = 0;
        public SquadLeaderTerrorist() : base("squad leader")
        {

        }

        public void Attack()
        {
            if (AttackCounter < 2)
            {
                this.AttackCounter++;
            }
            else
            {
                RemoveActive();
                AttackCounter = 0;

            }
        }

        public void RemoveActive()
        {
            List<Sensor> ActiveSensors = new List<Sensor>();
            Random Rand = new Random();

            foreach (Sensor sensor in WeaknesSensors)
            {
                if (sensor.Active)
                {
                    ActiveSensors.Add(sensor);
                }
            }

            Sensor sen = ActiveSensors.ElementAt(Rand.Next(ActiveSensors.Count));
            sen.Active = false;
        }
    }
}
