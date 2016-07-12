using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;

namespace ConnectFour.Managers
{
    public class GameManager
    {
        private readonly List<IGameValidator> m_GameVictoryValidators;
        private readonly IGameValidator m_ValidMovesRemainingValidator;
        private readonly IMoveValidator m_MoveValidator;

        public GameManager(IGameValidator validMovesRemainingValidator, IMoveValidator moveValidator, List<IGameValidator> victoryValidators)
        {
            m_ValidMovesRemainingValidator = validMovesRemainingValidator;
            m_GameVictoryValidators = victoryValidators;
            m_MoveValidator = moveValidator;
        }
        
        public void PlayGame()
        {
            string input = "";
            string playerName = "";
            Players currentPlayer = Players.None;
            GameGrid gameGrid;

            var turnCounter = 0;

            // Get Grid Size

            // Start Game
            // trim whie space.
            input = input.Replace(" ", "");
            var gameSize = input.Split(',');

            var rows = int.Parse(gameSize[0]);
            var columns = int.Parse(gameSize[1]);

            gameGrid = new GameGrid(rows, columns);

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

                Output(string.Format("{0} player, please pick a column between 0 and {1}", playerName, gameGrid.Columns - 1));

                // Get moes until a valid move is entered
                
                // Apply valid move

                // Check for Victory
                if (IsVictory(gameGrid, currentPlayer))
                {
                    Output(string.Format("{0} player is victorious!"));
                    break;
                }

                // Check for Draw
                if (IsDraw(gameGrid))
                {
                    Output("Draw! Better luck next time.");
                    break;
                }
            }
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
            // Console.WriteLine(output);
        }
    }
}
