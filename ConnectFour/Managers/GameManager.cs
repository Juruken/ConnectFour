using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;

namespace ConnectFour.Managers
{
    public class GameManager
    {
        private readonly IGridCreationValidator m_GridCreationValidator;
        private readonly List<IGameValidator> m_GameVictoryValidators;
        private readonly IGameValidator m_ValidMovesRemainingValidator;
        private readonly IMoveValidator m_MoveValidator;

        public GameManager(IGridCreationValidator gridCreationValidator, IGameValidator validMovesRemainingValidator, IMoveValidator moveValidator, List<IGameValidator> victoryValidators)
        {
            m_GridCreationValidator = gridCreationValidator;
            m_ValidMovesRemainingValidator = validMovesRemainingValidator;
            m_GameVictoryValidators = victoryValidators;
            m_MoveValidator = moveValidator;
        }
        
        public void PlayGame()
        {
            int rows, columns;
            string input, playerName;
            Players currentPlayer;
            GameGrid gameGrid;

            Output("Welcome to Connect Four!");
            Output("Please enter the board dimensions. You may have between 5-6 rows and 5-7 columns.");
            Output("Please enter the rows followed by a space and then the columns. e.g. '5 5'.");

            var turnCounter = 0;
            
            // Get Grid Size
            while (true)
            {
                input = Console.ReadLine();

                if (input == null || input.Length != 3)
                {
                    Output("Invalid input, please enter the rows followed by a space and then the columns. e.g. '5 5'");
                    continue;
                }

                if (m_GridCreationValidator.Validate(input[0].ToString(), input[2].ToString()))
                {
                    rows = int.Parse(input[0].ToString());
                    columns = int.Parse(input[2].ToString());
                    break;
                }

                Output("Invalid input, please enter the rows followed by a space and then the columns. e.g. '5 5'");
            }

            // Start Game
            // trim whie space.
            gameGrid = new GameGrid(rows, columns);

            WriteGridToConsole(gameGrid);

            while (true)
            {
                turnCounter++;

                // Determine Player Turn
                if (turnCounter%2 == 0)
                {
                    currentPlayer =  Players.Red;
                    playerName = "Red";
                }
                else
                {
                    currentPlayer = Players.Yellow;
                    playerName = "Yellow";
                }
                
                while (true)
                {
                    int column;
                    // Get moes until a valid move is entered
                    while (true)
                    {
                        Output(string.Format("{0} player, please pick a column between 0 and {1}", playerName, gameGrid.Columns - 1));

                        input = Console.ReadLine();

                        // Valid Input
                        if (input != null && input.Length == 1 && char.IsNumber(input[0]))
                        {
                            column = int.Parse(input[0].ToString());
                            break;
                        }

                        Output("Invalid input!");
                    }


                    // Validate move column
                    if (m_MoveValidator.Validate(gameGrid, column))
                    {
                        // Apply valid move
                        gameGrid.AddToken(column, currentPlayer);
                        break;
                    }

                    Output("Move is not valid");
                }

                // Check for Victory
                if (IsVictory(gameGrid, currentPlayer))
                {
                    Output(string.Format("{0} player is victorious!", playerName));
                    break;
                }

                // Check for Draw
                if (IsDraw(gameGrid))
                {
                    Output("Draw! Better luck next time.");
                    break;
                }

                WriteGridToConsole(gameGrid);
            }

            Output("Press any key to close the program.");
            Console.ReadLine();
        }

        private bool IsDraw(GameGrid gameGrid)
        {
            if (m_ValidMovesRemainingValidator.Validate(gameGrid, Players.None))
            {
                return false;
            }

            return true;
        }

        private bool IsVictory(GameGrid gameGrid, Players currentPlayer)
        {
            foreach (var victoryValidator in m_GameVictoryValidators)
            {
                if (victoryValidator.Validate(gameGrid, currentPlayer))
                    return true;
            }

            return false;
        }

        private void Output(string output)
        {
            Console.WriteLine(output);
        }

        private void WriteGridToConsole(GameGrid gameGrid)
        {
            Dictionary<Players, string> playerOutputString = new Dictionary<Players, string>
            {
                { Players.Yellow , "y" },
                { Players.Red, "r" },
                { Players.None, "o" },
            };

            Console.WriteLine("-------------------------------------------------");
            
            for (int i = gameGrid.Rows - 1; i >= 0; i--)
            {
                Console.WriteLine("      ");

                for (int j = 0; j < gameGrid.Columns; j++)
                {
                    Console.Write( string.Format(" {0} ", playerOutputString[gameGrid.Grid[i][j]]) );
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("-------------------------------------------------");
        }
    }
}
