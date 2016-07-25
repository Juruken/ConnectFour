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
        private readonly IGameGridProvider m_GameGridProvider;

        public GameFactory(IInputProvider inputProvider, IOutputProvider outputProvider,
            IGameGridProvider gameGridProvider)
        {
            m_InputProvider = inputProvider;
            m_OutputProvider = outputProvider;
            m_GameGridProvider = gameGridProvider;
        }

        public GridOutputProvider CreateGridOutputProvider()
        {
            return new GridOutputProvider(m_OutputProvider, m_GameGridProvider);
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
                new ConsoleInputProvider(),
                new ConsoleOutputProvider()
            );
        }
    }
}
