using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Validators
{
    public class MoveValidator : IMoveValidator
    {
        /// <summary>
        /// If the top move of the column is 
        /// </summary>
        /// <param name="gameGrid"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool Validate(GameGrid gameGrid, int column)
        {
            for (var i = 0; i < gameGrid.Rows; i++)
            {
                if (gameGrid.Grid[i][column] == Players.None)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
