using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class TermalSensor : Sensor
    {
        public TermalSensor(Terrorist terrorist) : base("termal", terrorist)
        {

        }
        public string UncoverOneSensor()
        {
            List<Sensor> NotActivateSensors = new List<Sensor>();
            Random Rand = new Random();
            string result;

            foreach (Sensor sensor in this._OwnerTerrorist.WeaknesSensors)
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
