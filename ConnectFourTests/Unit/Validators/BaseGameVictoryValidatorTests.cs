using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;

namespace ConnectFourTests.Unit.Validators
{
    public class BaseGameVictoryValidatorTests
    {
        protected IGameVictoryValidator m_GameVictoryValidator;
        protected Players m_WinningPlayer = Players.Yellow;
        protected Players m_LosingPlayer = Players.Red;

        protected GameGrid CreateGameGrid(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = new GameGrid(rows, columns);
            PopulateGameGrid(gameGrid, rowsToPopulate, columnsToPopulate);
            return gameGrid;
        }

        protected GameGrid CreateGameGrid(int rows, int columns, List<Tuple<int,int>> rowColumnsToPopulate)
        {
            var gameGrid = new GameGrid(rows, columns);
            PopulateGameGrid(gameGrid, rowColumnsToPopulate);
            return gameGrid;
        }

        private void PopulateGameGrid(GameGrid gameGrid, List<Tuple<int, int>> rowColumnsToPopulate)
        {
            foreach (var tokenToPlace in rowColumnsToPopulate)
            {
                gameGrid.Grid[tokenToPlace.Item1][tokenToPlace.Item2] = m_WinningPlayer;
            }
        }

        private void PopulateGameGrid(GameGrid gameGrid, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var rows = gameGrid.Rows;
            var columns = gameGrid.Rows;

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
        }
    }
}
