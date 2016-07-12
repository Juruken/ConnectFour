using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFourTests.Unit
{
    public class BaseGameTests
    {
        protected GameGrid CreateGameGrid(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate, Players player = Players.None)
        {
            var gameGrid = new GameGrid(rows, columns);
            PopulateGameGrid(gameGrid, rowsToPopulate, columnsToPopulate, player);
            return gameGrid;
        }

        protected GameGrid CreateGameGrid(int rows, int columns, List<Tuple<int, int>> rowColumnsToPopulate, Players player = Players.None)
        {
            var gameGrid = new GameGrid(rows, columns);
            PopulateGameGrid(gameGrid, rowColumnsToPopulate, player);
            return gameGrid;
        }

        private void PopulateGameGrid(GameGrid gameGrid, List<Tuple<int, int>> rowColumnsToPopulate, Players player)
        {
            foreach (var tokenToPlace in rowColumnsToPopulate)
            {
                gameGrid.Grid[tokenToPlace.Item1][tokenToPlace.Item2] = player;
            }
        }

        private void PopulateGameGrid(GameGrid gameGrid, List<int> rowsToPopulate, List<int> columnsToPopulate, Players player)
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
                        gameGrid.Grid[i][j] = player;
                    }
                }
            }
        }
    }
}
