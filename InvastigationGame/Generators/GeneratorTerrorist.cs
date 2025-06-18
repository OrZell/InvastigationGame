using InvastigationGame.Models.Sensors;
using InvastigationGame.Models.Terrorists;

namespace InvastigationGame.Generators
{
    public class GeneratorTerrorist
    {
        public static Terrorist GenerateRandomTerrorist()
        {
            Random Rand = new Random();
            List<string> types = ProgramStaticData.StaticData.TypesAndMuchSensors.Keys.ToList();
            string type = types.ElementAt(Rand.Next(types.Count));

            Terrorist terrorist;

            switch (type)
            {
                case "foot":
                    terrorist = GenearteFootTerrorist();
                    break;

                case "squad leader":
                    terrorist = GenerateSquadLeaderTerrorist();
                    break;

                case "senior commander":
                    terrorist = GenerateSeniorCommanderTerrorist();
                    break;

                case "organization leader":
                    terrorist = GenerateOrganizationLeaderterrorist();
                    break;

                default:
                    terrorist = GenearteFootTerrorist();
                    break;
            }
            return terrorist;
        }



        public static Terrorist GenearteFootTerrorist()
        {
            Terrorist terrorist = new FootTerrorist();
            return GenerateTerrorist(terrorist);
        }

        public static Terrorist GenerateSquadLeaderTerrorist()
        {
            Terrorist terrorist = new SquadLeaderTerrorist();
            return GenerateTerrorist(terrorist);
        }

        public static Terrorist GenerateSeniorCommanderTerrorist()
        {
            Terrorist terrorist = new SeniorCommanderTerrorist();
            return GenerateTerrorist(terrorist);
        }

        public static Terrorist GenerateOrganizationLeaderterrorist()
        {
            Terrorist terrorist = new OrganizationLeaderTerrorist();
            return GenerateTerrorist(terrorist);
        }

        private static Terrorist GenerateTerrorist(Terrorist terrorist)
        {
            terrorist.WeaknesSensors = GeneraorSensor.GenerateSomeRandomSensors(terrorist);
            terrorist.Touched = new List<Sensor>();
            return terrorist;
        }
    }
}
