using System;
using ConnectFour.Constants;

namespace ConnectFour.DataModel
{
    public class GameGrid
    {
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Grid = new Players[Rows][];

            for (var i = 0; i < Rows; i++)
            {
                Grid[i] = new Players[Columns];
            }
        }
        
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Players[][] Grid { get; set; }

        public void ResetGrid()
        {
            // Initialise the grid to blank
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    Grid[i][j] = Players.None;
                }
            }
        }
        
        public void AddToken(int column, Players player)
        {
            for (int i = 0; i < Rows; i++)
            {
                if (Grid[i][column] == Players.None)
                {
                    Grid[i][column] = player;
                    return;
                }
            }

            throw new ArgumentException("Invalid move, column is full.");
        }
    }
}
