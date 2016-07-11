using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFourTests.Unit.Validators
{
    public class BaseGameVictoryValidatorTests
    {
        protected Players m_WinningPlayer = Players.Yellow;
        protected Players m_LosingPlayer = Players.Red;

        protected GameGrid CreateGameGrid(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = new GameGrid(rows, columns);

            for (var i = 0; i < rows; i++)
            {
                if (!rowsToPopulate.Contains(i))
                    continue;

                for (var j = 0; j < columns; j++)
                {
                    if (columnsToPopulate.Contains(j))
                    {
                        gameGrid.Grid[i][j] = m_WinningPlayer;
                    }
                }
            }

            return gameGrid;
        }
    }
}
