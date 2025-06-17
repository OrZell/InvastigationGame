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
                Sensor sensor = CreateSensor(type, terrorist);
                sensors.Add(sensor);
            }
            return sensors;
        }

        public static Sensor CreateSensor(string type, Terrorist terrorist)
        {
            Sensor sensor;

            switch (type)
            {
                case "movement":
                    sensor = new MovementSensor(terrorist);
                    break;

                case "lighing":
                    sensor = new LightingSensor(terrorist);
                    break;

                case "selolar":
                    sensor = new SelolarSensor(terrorist);
                    break;

                case "pulse":
                    sensor = new PulseSensor(terrorist);
                    break;

                case "magnet":
                    sensor = new MagneticSensor(terrorist);
                    break;

                case "termal":
                    sensor = new TermalSensor(terrorist);
                    break;

                case "signal":
                    sensor = new SignalSensor(terrorist);
                    break;

                default:
                    sensor = new Sensor(type, terrorist);
                    break;
            }
            return sensor;
        }
    }
}
