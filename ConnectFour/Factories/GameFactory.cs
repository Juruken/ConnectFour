using System.Collections.Generic;
using ConnectFour.Managers;
using ConnectFour.Providers;
using ConnectFour.Validators;

namespace ConnectFour.Factories
{
    public class GameFactory
    {
        private readonly IOutputProvider m_OutputProvider;
        private readonly IInputProvider m_InputProvider;
        private readonly IGridOutputProvider m_GridOutputProvider;

        public GameFactory(IInputProvider inputProvider, IOutputProvider outputProvider, IGridOutputProvider gridOutputProvider)
        {
            m_InputProvider = inputProvider;
            m_OutputProvider = outputProvider;
            m_GridOutputProvider = gridOutputProvider;
        }
        
        public GameManager CreateGameManager()
        {
            return new GameManager(
                new GridCreationValidator(),
                new ValidMovesRemainingValidator(), 
                new MoveValidator(),
                new List<IGameValidator>
                {
                    new VerticalGameVictoryValidator(),
                    new HorizontalGameVictoryValidator(),
                    new DiagonalGameVictoryValidator()
                },
                m_InputProvider,
                m_OutputProvider,
                m_GridOutputProvider
            );
        }
    }
}
