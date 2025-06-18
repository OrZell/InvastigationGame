using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class MagneticSensor : Sensor
    {
        public int DefenceCounter;
        public MagneticSensor() : base("magnet")
        {
            this.DefenceCounter = 2;
        }
    }
}
