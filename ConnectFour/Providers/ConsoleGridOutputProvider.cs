using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;

namespace ConnectFour.Providers
{
    public class ConsoleGridOutputProvider : IGridOutputProvider
    {
        public void Output(GameGrid gameGrid)
        {
            Dictionary<Players, string> playerOutputString = new Dictionary<Players, string>
            {
                { Players.Yellow , "y" },
                { Players.Red, "r" },
                { Players.None, "o" },
            };

            Console.WriteLine("-------------------------------------------------");

            for (var i = gameGrid.Rows - 1; i >= 0; i--)
            {
                Console.WriteLine("      ");

                for (var j = 0; j < gameGrid.Columns; j++)
                {
                    Console.Write($" {playerOutputString[gameGrid.Grid[i][j]]} ");
                }

                Console.WriteLine("      ");
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
