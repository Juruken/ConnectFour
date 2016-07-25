using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Providers;
using ConnectFour.Validators;

namespace ConnectFour.Managers
{
    public class GameManager
    {
        private readonly IGridCreationValidator m_GridCreationValidator;
        private readonly List<IGameValidator> m_GameVictoryValidators;
        private readonly IGameValidator m_ValidMovesRemainingValidator;
        private readonly IMoveValidator m_MoveValidator;
        private readonly IInputProvider m_InputProvider;
        private readonly IOutputProvider m_OutputProvider;

        public GameManager(IGridCreationValidator gridCreationValidator, IGameValidator validMovesRemainingValidator, IMoveValidator moveValidator, List<IGameValidator> victoryValidators, 
                            IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            m_GridCreationValidator = gridCreationValidator;
            m_ValidMovesRemainingValidator = validMovesRemainingValidator;
            m_GameVictoryValidators = victoryValidators;
            m_MoveValidator = moveValidator;
            m_InputProvider = inputProvider;
            m_OutputProvider = outputProvider;
        }
        
        public void PlayGame()
        {
            int rows, columns;
            string input, playerName;
            Players currentPlayer;
            GameGrid gameGrid;

            m_OutputProvider.Output("Welcome to Connect Four!");
            m_OutputProvider.Output("Please enter the board dimensions. You may have between 5-6 rows and 5-7 columns.");
            m_OutputProvider.Output("Please enter the rows followed by a space and then the columns. e.g. '5 5'.");

            var turnCounter = 0;
            
            // Get Grid Size
            while (true)
            {
                input = m_InputProvider.GetInput();

                if (input == null || input.Length != 3)
                {
                    m_OutputProvider.Output("Invalid input, please enter the rows followed by a space and then the columns. e.g. '5 5'");
                    continue;
                }

                if (m_GridCreationValidator.Validate(input[0].ToString(), input[2].ToString()))
                {
                    rows = int.Parse(input[0].ToString());
                    columns = int.Parse(input[2].ToString());
                    break;
                }

                m_OutputProvider.Output("Invalid board size! You may have between 5-6 rows and 5-7 columns.");
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
                        m_OutputProvider.Output(string.Format("{0} player, please pick a column between 1 and {1}", playerName, gameGrid.Columns));

                        input = m_InputProvider.GetInput();

                        // Valid Input
                        if (input != null && input.Length == 1 && char.IsNumber(input[0]))
                        {
                            column = int.Parse(input[0].ToString());
                            break;
                        }

                        m_OutputProvider.Output("Invalid input!");
                    }


                    // Validate move column
                    if (m_MoveValidator.Validate(gameGrid, column - 1))
                    {
                        // Apply valid move
                        gameGrid.AddToken(column - 1, currentPlayer);
                        break;
                    }

                    m_OutputProvider.Output("Move is not valid");
                }

                WriteGridToConsole(gameGrid);

                // Check for Victory
                if (IsVictory(gameGrid, currentPlayer))
                {
                    m_OutputProvider.Output(string.Format("{0} player is victorious!", playerName));
                    break;
                }

                // Check for Draw
                if (IsDraw(gameGrid))
                {
                    m_OutputProvider.Output("Draw! Better luck next time.");
                    break;
                }
            }

            m_OutputProvider.Output("Press any key to close the program.");
            m_InputProvider.GetInput();
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
        
        // TODO: Make this use the OutputProvider
        private void WriteGridToConsole(GameGrid gameGrid)
        {
            
        }
    }
}
