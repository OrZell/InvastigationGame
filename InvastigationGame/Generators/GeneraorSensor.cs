using InvastigationGame.Models.Sensors;
using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Generators
{
    public class GeneraorSensor
    {
        public static List<Sensor> GenerateSomeRandomSensors(Terrorist terrorist)
        {
            List<Sensor> sensors = new List<Sensor>();

            List<string> types = ProgramStaticData.StaticData.TypesOfSensors;
            Random Rand = new Random();

            for (int i = 0; i < terrorist.Capacity; i++)
            {
                string type = types.ElementAt(Rand.Next(types.Count));
                Sensor sensor = CreateSensor(type);
                sensors.Add(sensor);
            }
            return sensors;
        }

        public static Sensor CreateSensor(string type)
        {
            Sensor sensor;

            switch (type)
            {
                case "movement":
                    sensor = new MovementSensor();
                    break;

                case "lighing":
                    sensor = new LightingSensor();
                    break;

                case "selolar":
                    sensor = new SelolarSensor();
                    break;

                case "pulse":
                    sensor = new PulseSensor();
                    break;

                case "magnet":
                    sensor = new MagneticSensor();
                    break;

                case "termal":
                    sensor = new TermalSensor();
                    break;

                case "signal":
                    sensor = new SignalSensor();
                    break;

                default:
                    sensor = new Sensor(type);
                    break;
            }
            return sensor;
        }
    }
}
