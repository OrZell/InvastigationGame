using InvastigationGame.Models.Terrorists;
using InvastigationGame.Generators;
using InvastigationGame.PlayerDal;

namespace InvastigationGame
{
    public class GameManager
    {
        public int CurrentLevel;
        public Menu menu;
        public PlayerDAL PDA;


        public GameManager()
        {
            this.CurrentLevel = 1;
            this.menu = new Menu();
            this.PDA = new PlayerDAL();
        }

        public void StartGame()
        {
            Player player = GeneratePlayer();
            this.CurrentLevel = player.Level;
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
                            SaveGame(player);
                            return;
                        }
                        this.CurrentLevel++;
                        player.Level = this.CurrentLevel;
                        break;

                    case 2:
                        SquadLeaderTerrorist squadLeaderTerrorist = (SquadLeaderTerrorist)GeneratorTerrorist.GenerateSquadLeaderTerrorist();
                        Console.WriteLine("\n<<<<<<<< Level 2 >>>>>>>>");
                         Exit = this.menu.MainMenu(this.CurrentLevel, squadLeaderTerrorist);
                        if (Exit == "Exit")
                        {
                            SaveGame(player);
                            return;
                        }
                        this.CurrentLevel++;
                        player.Level = this.CurrentLevel;
                        break;

                    case 3:
                        SeniorCommanderTerrorist seniorCommanderTerrorist = (SeniorCommanderTerrorist)GeneratorTerrorist.GenerateSeniorCommanderTerrorist();
                        Console.WriteLine("\n<<<<<<<< Level 3 >>>>>>>>");
                        Exit = this.menu.MainMenu(this.CurrentLevel, seniorCommanderTerrorist);
                        if (Exit == "Exit")
                        {
                            SaveGame(player);
                            return;
                        }
                        this.CurrentLevel++;
                        player.Level = this.CurrentLevel;
                        break;

                    case 4:
                        OrganizationLeaderTerrorist organizationLeaderTerrorist = (OrganizationLeaderTerrorist)GeneratorTerrorist.GenerateOrganizationLeaderterrorist();
                        Console.WriteLine("\n<<<<<<<< Level 1 >>>>>>>>");
                        Exit = this.menu.MainMenu(this.CurrentLevel, organizationLeaderTerrorist);
                        if (Exit == "Exit")
                        {
                            SaveGame(player);
                            return;
                        }
                        this.CurrentLevel++;
                        player.Level = this.CurrentLevel;
                        DoneAll = true;
                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine("You Done All");
        }

        public void SaveGame(Player player)
        {
            this.PDA.UpdateLevel(player);
        }

        public Player GeneratePlayer()
        {
            string Name = Player.EnterUserName();
            Player player = this.PDA.FindByName(Name);
            if (player == null)
            {
                player = new Player(Name);
                this.PDA.AddPlayer(player);
            }
            return player;
        }
    }
}
