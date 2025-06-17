using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class MovementSensor : Sensor
    {
        public MovementSensor(Terrorist terrorist) : base("movement", terrorist)
        {

        }
    }
}