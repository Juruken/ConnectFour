using System;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public class ValidMovesRemainingValidator : IGameValidator
    {
        /// <summary>
        /// If there is any spot that is currently not filled, there are valid moves remaining.
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool Validate(GameGrid gameGrid, Players player)
        {
            if (player != Players.None)
            {
                throw new ArgumentException("Unexpected player.");
            }

            for (var i = 0; i < gameGrid.Rows; i++)
            {
                for (int j = 0; j < gameGrid.Columns; j++)
                {
                    if (gameGrid.Grid[i][j] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
