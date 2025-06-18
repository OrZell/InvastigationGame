namespace InvastigationGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = Player.CreateUser();
            Menu menu = new Menu();
            GameManager game = new GameManager(menu, player);
            game.StartGame();
        }
    }
}