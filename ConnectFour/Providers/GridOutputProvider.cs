using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Providers
{
    public class GridOutputProvider : IGridOutputProvider
    {
        private readonly IGameGridProvider m_GameGridProvider;
        private readonly IOutputProvider m_OutputProvider;

        public GridOutputProvider(IOutputProvider outputProvider, IGameGridProvider gameGridProvider)
        {
            m_GameGridProvider = gameGridProvider;
            m_OutputProvider = outputProvider;
        }

        public void Output()
        {
            var gameGrid = m_GameGridProvider.GetGameGrid();

            Dictionary<Players, string> playerOutputString = new Dictionary<Players, string>
            {
                { Players.Yellow , "y" },
                { Players.Red, "r" },
                { Players.None, "o" },
            };

            m_OutputProvider.Output("-------------------------------------------------");

            for (var i = gameGrid.Rows - 1; i >= 0; i--)
            {
                m_OutputProvider.Output("      ");

                for (var j = 0; j < gameGrid.Columns; j++)
                {
                    m_OutputProvider.Output($" {playerOutputString[gameGrid.Grid[i][j]]} ");
                }
            }

            m_OutputProvider.Output("-------------------------------------------------");
        }
    }
}
