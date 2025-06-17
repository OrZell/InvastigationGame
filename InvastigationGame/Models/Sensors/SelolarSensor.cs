using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class SelolarSensor : Sensor
    {
        public SelolarSensor(Terrorist terrorist) : base("selolar", terrorist)
        {

        }
    }
}