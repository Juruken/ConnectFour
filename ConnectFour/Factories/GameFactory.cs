using System.Collections.Generic;
using ConnectFour.Managers;
using ConnectFour.Validators;

namespace ConnectFour.Factories
{
    public class GameFactory
    {
        public GameManager CreateGameManager()
        {
            return new GameManager(
                new GridCreationValidator(),
                new ValidMovesRemainingValidator(), 
                new MoveValidator(),
                new List<IGameValidator>
                {
                    new VerticalGameVictoryValidator(),
                    new HorizontalGameVictoryValidator(),
                    new DiagonalGameVictoryValidator()
                }
            );
        }
    }
}
