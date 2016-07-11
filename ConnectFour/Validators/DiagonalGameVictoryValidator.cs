using System.Runtime.InteropServices;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public class DiagonalGameVictoryValidator : IGameVictoryValidator
    {
        public bool Validate(GameGrid gameGrid, Players player)
        {
            return ValidateDownAndRight(gameGrid, player)
                || ValidateDownAndLeft(gameGrid, player);
        }

        /// <summary>
        /// Check for diagonal win, going down and right
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateDownAndRight(GameGrid gameGrid, Players player)
        {
            var grid = gameGrid.Grid;

            // We want to ALWAYS do 3 at max?
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

        /// <summary>
        /// Check for diagonal win, going down and left (starting far right)
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateDownAndLeft(GameGrid gameGrid, Players player)
        {
            var grid = gameGrid.Grid;
            
            // Start at the highest row
            for (var i = gameGrid.Rows - 1 ; i > 3; i--)
            {
                // Why only 3?
                // TODO: Figure out... how high to go..
                for (var j = 0; j < gameGrid.Columns - 3; j++)
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
        /// Check for diagonal win, going up and right (starting bottom left)
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateUpAndRight(GameGrid gameGrid, Players player)
        {
            var grid = gameGrid.Grid;
            throw new System.NotImplementedException();

            /*for (i = 0; i < 3; i++)
            {
                for (j = 6; j > 2; j--)
                {
                    var token1 = grid[i][j];
                    var token2 = grid[i + 1][j - 1];
                    var token3 = grid[i + 2][j - 2];
                    var token4 = grid[i + 3][j - 3];

                    if (token1 == player
                        && token2 == player
                        && token3 == player
                        && token4 == player)
                        return true;                }
            }*/
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
            throw new System.NotImplementedException();
            /*for (var i = 5; i > 3; i--)
            {
                for (var j = 6; j > 2; j--)
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
            }*/
        }
    }
}
