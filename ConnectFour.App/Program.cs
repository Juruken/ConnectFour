using ConnectFour.Factories;

namespace ConnectFour.App
{
    class Program
    {
        static void Main(string[] args)
        {
             var gameFactory = new GameFactory();
             var gameManager = gameFactory.CreateGameManager();
             gameManager.PlayGame();
        }
    }
}
