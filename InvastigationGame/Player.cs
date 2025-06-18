using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static Player CreateUser()
        {
            Console.WriteLine("Enter Your Name");
            string Name = Console.ReadLine()!;
            return new Player(Name);
        }
    }
}
