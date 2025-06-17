using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class LightingSensor : Sensor
    {
        public LightingSensor(Terrorist terrorist) : base("lighting", terrorist)
        {

        }
    }
}