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

        public GameManager(IGameValidator validMovesRemainingValidator, List<IGameValidator> victoryValidators)
        {
            m_ValidMovesRemainingValidator = validMovesRemainingValidator;
            m_GameVictoryValidators = victoryValidators;
        }

        public bool IsDraw(GameGrid gameGrid)
        {
            foreach (var victoryValidator in m_GameVictoryValidators)
            {
                if (victoryValidator.Validate(gameGrid, Players.Yellow)
                    || victoryValidator.Validate(gameGrid, Players.Red))
                    return false;
            }

            if (m_ValidMovesRemainingValidator.Validate(gameGrid, Players.None))
            {
                return false;
            }

            return true;
        }
    }
}
