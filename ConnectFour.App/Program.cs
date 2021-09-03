using ConnectFour.Factories;
using ConnectFour.Providers;

namespace ConnectFour.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputProvider = new ConsoleInputProvider();
            var outputProvider = new ConsoleOutputProvider();
            var gridOutputProvider = new ConsoleGridOutputProvider();

            var gameFactory = new GameFactory(inputProvider, outputProvider, gridOutputProvider);
            var gameManager = gameFactory.CreateGameManager();
            gameManager.PlayGame();
        }
    }
}
