using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public class VerticalGameVictoryValidator : IGameValidator
    {
        // Check for a specific player victory
        public bool Validate(GameGrid gameGrid, Players player)
        {
            var gameBoard = gameGrid.Grid;

            // Rows
            // There is a minimum of 5 rows, and a maximum rows of 7
            // For a grid of 5 rows, if we check rows 0-1 we have checked all possibilities for that column
            // For a grid of 6 rows, if we check rows 0-2 we have checked all possibilities for that column
            // For a grid of 7 rows, if we check rows 0-3 we have checked all possibilities for that column
            for (var i = 0; i < gameBoard.Length - 3; i++)
            {
                // Columns
                for (var j = 0; j < gameBoard[i].Length; j++)
                {
                    var token1 = gameBoard[i][j];
                    var token2 = gameBoard[i + 1][j];
                    var token3 = gameBoard[i + 2][j];
                    var token4 = gameBoard[i + 3][j];

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
