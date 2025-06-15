using InvastigationGame.Models.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
