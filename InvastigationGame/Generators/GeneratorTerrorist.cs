using InvastigationGame.Models.Terrorists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvastigationGame.Generators
{
    public class GeneratorTerrorist
    {
        public static Terrorist GeneartePrivateTerrorist()
        {
            int manySens = ProgramStaticData.StaticData.TypesAndMuchSensors["private"];
            Terrorist terrorist = new PrivateTerrorist();
            terrorist.WeaknesSensors = GeneraorSensor.GenerateSomeRandomSensors(manySens);
            return terrorist;
        }
    }
}
