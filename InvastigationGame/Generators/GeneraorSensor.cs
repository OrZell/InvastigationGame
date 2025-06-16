using InvastigationGame.Models.Sensors;

namespace InvastigationGame.Generators
{
    public class GeneraorSensor
    {
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

                default:
                    sensor = new Sensor(type);
                    break;
            }
            return sensor;
        }

        public static List<Sensor> GenerateSomeRandomSensors(int howMany)
        {
            List<Sensor> sensors = new List<Sensor>();

            List<string> types = ProgramStaticData.StaticData.TypesOfSensors;
            Random Rand = new Random();

            for (int i = 0; i < howMany; i++)
            {
                string type = types.ElementAt(Rand.Next(types.Count));
                Sensor sensor = CreateSensor(type);
                sensors.Add(sensor);
            }
            return sensors;
        }
    }
}
