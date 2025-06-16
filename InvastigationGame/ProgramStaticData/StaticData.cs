using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvastigationGame.ProgramStaticData
{
    public class StaticData
    {
        public static Dictionary<string, int> TypesAndMuchSensors = new Dictionary<string, int> { { "private", 2 }, {"squad leader", 4 };

        public static List<string> TypesOfSensors = new List<string> { { "movement" }, { "lighting" }, { "selolar" } };
    }
}
