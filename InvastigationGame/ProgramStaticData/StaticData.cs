namespace InvastigationGame.ProgramStaticData
{
    public class StaticData
    {
        public static Dictionary<string, int> TypesAndMuchSensors = new Dictionary<string, int>
        { 
            { "foot", 2 }, 
            { "squad leader", 4 }, 
            { "senior commander", 6 },
            { "organization leader", 8 }
        };

        public static List<string> TypesOfSensors = new List<string> 
        { 
            "movement", 
            "lighting", 
            "selolar", 
            "pulse"
        };
    }
}
