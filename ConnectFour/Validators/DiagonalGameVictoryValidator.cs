using System.Runtime.InteropServices;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public class DiagonalGameVictoryValidator : IGameVictoryValidator
    {
        public bool Validate(GameGrid gameGrid, Players player)
        {
            return ValidateDownAndRight(gameGrid, player) || ValidateDownAndLeft(gameGrid, player);
        }

        /// <summary>
        /// Check for diagonal win, going down and right
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateDownAndRight(GameGrid gameGrid, Players player)
        {
            throw new System.NotImplementedException();

            /*for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    temp[0] = gameBoard[i][j];
                    temp[1] = gameBoard[i + 1][j + 1];
                    temp[2] = gameBoard[i + 2][j + 2];
                    temp[3] = gameBoard[i + 3][j + 3];
                    done = checksForWin(temp);
                    if (done)
                    {
                        return done;
                    }
                }
            }*/
        }

        /// <summary>
        /// Check for diagonal win, going down and left (starting far right)
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateDownAndLeft(GameGrid gameGrid, Players player)
        {
            throw new System.NotImplementedException();
            /*for (i = 5; i > 3; i--)
            {
                for (j = 0; j < 3; j++)
                {
                    temp[0] = gameBoard[i][j];
                    temp[1] = gameBoard[i - 1][j + 1];
                    temp[2] = gameBoard[i - 2][j + 2];
                    temp[3] = gameBoard[i - 3][j + 3];
                    done = checksForWin(temp);
                    if (done)
                    {
                        return done;
                    }
                }
            }*/
        }

        /// <summary>
        /// Check for diagonal win, going up and right (starting bottom left)
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        private bool ValidateUpAndRight(GameGrid gameGrid, Players player)
        {
            throw new System.NotImplementedException();
            
            /*for (i = 0; i < 3; i++)
            {
                for (j = 6; j > 2; j--)
                {
                    temp[0] = gameBoard[i][j];
                    temp[1] = gameBoard[i + 1][j - 1];
                    temp[2] = gameBoard[i + 2][j - 2];
                    temp[3] = gameBoard[i + 3][j - 3];
                    done = checksForWin(temp);
                    if (done)
                    {
                        return done;
                    }
                }
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
            throw new System.NotImplementedException();
            /*for (i = 5; i > 3; i--)
            {
                for (j = 6; j > 2; j--)
                {
                    temp[0] = gameBoard[i][j];
                    temp[1] = gameBoard[i - 1][j - 1];
                    temp[2] = gameBoard[i - 2][j - 2];
                    temp[3] = gameBoard[i - 3][j - 3];
                    done = checksForWin(temp);
                    if (done)
                    {
                        return done;
                    }
                }
            }*/
        }
    }
}
