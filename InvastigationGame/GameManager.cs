using InvastigationGame.Models.Terrorists;
using InvastigationGame.Generators;

namespace InvastigationGame
{
    public class GameManager
    {
        public int CurrentLevel;
        public Menu menu;
        public Player player;

        public GameManager(Menu menu, Player player)
        {
            this.CurrentLevel = 1;
            this.menu = menu;
            this.player = player;
        }

        public Player StartGame()
        {
            string Exit = "";
            bool DoneAll = false;
            while (!DoneAll)
            {
                switch (this.CurrentLevel)
                {
                    case 1:
                        FootTerrorist footTerrorist = (FootTerrorist)GeneratorTerrorist.GenearteFootTerrorist();
                        Console.WriteLine("<<<<<<<< Level 1 >>>>>>>>");
                        Exit = this.menu.MainMenu(this.CurrentLevel, footTerrorist);
                        if (Exit == "Exit")
                        {
                            return this.player;
                        }
                        this.CurrentLevel++;
                        this.player.Level = this.CurrentLevel;
                        break;

                    case 2:
                        SquadLeaderTerrorist squadLeaderTerrorist = (SquadLeaderTerrorist)GeneratorTerrorist.GenerateSquadLeaderTerrorist();
                        Console.WriteLine("\n<<<<<<<< Level 2 >>>>>>>>");
                         Exit = this.menu.MainMenu(this.CurrentLevel, squadLeaderTerrorist);
                        if (Exit == "Exit")
                        {
                            return this.player;
                        }
                        this.CurrentLevel++;
                        this.player.Level = this.CurrentLevel;
                        break;

                    case 3:
                        SeniorCommanderTerrorist seniorCommanderTerrorist = (SeniorCommanderTerrorist)GeneratorTerrorist.GenerateSeniorCommanderTerrorist();
                        Console.WriteLine("\n<<<<<<<< Level 3 >>>>>>>>");
                        Exit = this.menu.MainMenu(this.CurrentLevel, seniorCommanderTerrorist);
                        if (Exit == "Exit")
                        {
                            return this.player;
                        }
                        this.CurrentLevel++;
                        this.player.Level = this.CurrentLevel;
                        break;

                    case 4:
                        OrganizationLeaderTerrorist organizationLeaderTerrorist = (OrganizationLeaderTerrorist)GeneratorTerrorist.GenerateOrganizationLeaderterrorist();
                        Console.WriteLine("\n<<<<<<<< Level 1 >>>>>>>>");
                        Exit = this.menu.MainMenu(this.CurrentLevel, organizationLeaderTerrorist);
                        if (Exit == "Exit")
                        {
                            return this.player;
                        }
                        this.CurrentLevel++;
                        this.player.Level = this.CurrentLevel;
                        DoneAll = true;
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine("You Done All");
            return this.player;
        }
    }
}
