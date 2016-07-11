using ConnectFour.Constants;

namespace ConnectFour.DataModel
{
    public class GameGrid
    {
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            CreateGrid();
        }
        
        public int Rows { get; set; }
        public int Columns { get; set; }

        public Players[][] Grid { get; set; }

        private void CreateGrid()
        {
            int i, j;
            Grid = new Players[Rows][];

            for (i = 0; i < Rows; i++)
            {
                Grid[i] = new Players[Columns];
            }

            // Initialise the grid to blank./
            for (i = 0; i < Rows; i++)
            {
                for (j = 0; j < Columns; j++)
                {
                    Grid[i][j] = Players.None;
                }
            }
        }
    }
}
