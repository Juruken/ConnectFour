using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public class HorizontalGameVictoryValidator : IGameVictoryValidator
    {
        public bool Validate(GameGrid gameGrid, Players player)
        {
            var gameBoard = gameGrid.Grid;

            // Rows
            for (var i = 0; i < gameBoard.Length; i++)
            {
                // Columns
                // There is a minimum of 5 columns, and a maximum columns of 7
                // For a grid of 5 columns, if we check columns 0-1 we have checked all possibilities for that row
                // For a grid of 6 columns, if we check columns 0-2 we have checked all possibilities for that row
                // For a grid of 7 columns, if we check columns 0-3 we have checked all possibilities for that row
                for (var j = 0; j < gameBoard[i].Length - 3; j++)
                {
                    var token1 = gameBoard[i][j];
                    var token2 = gameBoard[i][j + 1];
                    var token3 = gameBoard[i][j + 2];
                    var token4 = gameBoard[i][j + 3];

                    if (token1 == player
                        && token2 == player
                        && token3 == player
                        && token4 == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
