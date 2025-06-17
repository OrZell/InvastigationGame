using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Models.Sensors
{
    public class MagneticSensor : Sensor
    {
        public int DefenceCounter;
        public MagneticSensor(Terrorist terrorist) : base("magnetic", terrorist)
        {
            this.DefenceCounter = 2;
        }

        public void DefenceFromTheTerrorirst()
        {
            
        }
    }
}
