using InvastigationGame.PlayerDal;

namespace InvastigationGame
{ 
    public class Player
    {
        public string Name;
        public int Level;

        public Player(string name, int level = 1)
        {
            this.Name = name;
            this.Level = level;
        }

        public static string EnterUserName()
        {
            Console.WriteLine("Enter Your Name");
            string Name = Console.ReadLine()!;
            return Name;
        }
    }
}
