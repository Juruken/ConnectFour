using System.Runtime.InteropServices;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public class DiagonalGameVictoryValidator : IGameVictoryValidator
    {
        public bool Validate(GameGrid gameGrid, Players player)
        {
            return ValidateFromBottomLeft(gameGrid, player)
                || ValidateFromTopLeft(gameGrid, player)
                || ValidateDownAndLeft(gameGrid, player)
                || ValidateUpAndLeft(gameGrid, player);
        }
        
        private bool ValidateFromBottomLeft(GameGrid gameGrid, Players player)
        {
            var grid = gameGrid.Grid;

            for (var i = 0; i < gameGrid.Rows - 3; i++)
            {
                for (var j = 0; j < gameGrid.Columns - 3; j++)
                {
                    var token1 = grid[i][j];
                    var token2 = grid[i + 1][j + 1];
                    var token3 = grid[i + 2][j + 2];
                    var token4 = grid[i + 3][j + 3];

                    if (token1 == player
                        && token2 == player
                        && token3 == player
                        && token4 == player)
                        return true;
                }
            }

            return false;
        }
        
        private bool ValidateFromTopLeft(GameGrid gameGrid, Players player)
        {
            var grid = gameGrid.Grid;

            for (var i = 0; i < gameGrid.Rows - 3; i++)
            {
                for (var j = gameGrid.Columns - 1; j > 2; j--)
                {
                    var token1 = grid[i][j];
                    var token2 = grid[i + 1][j - 1];
                    var token3 = grid[i + 2][j - 2];
                    var token4 = grid[i + 3][j - 3];

                    if (token1 == player
                        && token2 == player
                        && token3 == player
                        && token4 == player)
                        return true;
                }
            }

            return false;
        }

        /*/// <summary>
        /// Check for diagonal win, going down and left (starting far right)
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateDownAndLeft(GameGrid gameGrid, Players player)
        {
            var grid = gameGrid.Grid;

            // Start at the highest row
            for (var i = gameGrid.Rows - 1; i > 3; i--)
            {
                // Why only 3?
                for (var j = 0; j < gameGrid.Columns - 4; j++)
                {
                    var token1 = grid[i][j];
                    var token2 = grid[i - 1][j + 1];
                    var token3 = grid[i - 2][j + 2];
                    var token4 = grid[i - 3][j + 3];

                    if (token1 == player
                        && token2 == player
                        && token3 == player
                        && token4 == player)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Check for diagonal win, going up and left (starting bottom right)
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateUpAndLeft(GameGrid gameGrid, Players player)
        {
            var grid = gameGrid.Grid;

            for (var i = gameGrid.Rows - 1; i > 3; i--)
            {
                for (var j = gameGrid.Columns - 1; j > 2; j--)
                {
                    var token1 = grid[i][j];
                    var token2 = grid[i - 1][j - 1];
                    var token3 = grid[i - 2][j - 2];
                    var token4 = grid[i - 3][j - 3];
                    
                    if (token1 == player
                        && token2 == player
                        && token3 == player
                        && token4 == player)
                        return true;
                }
            }
            
             return false;
        }*/
    }
}
