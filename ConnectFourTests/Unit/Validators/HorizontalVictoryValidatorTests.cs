using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class HorizontalVictoryValidatorTests
    {
        private IGameVictoryValidator m_GameVictoryValidator;

        [SetUp]
        public void Setup()
        {
            // TODO: Determine if we want to inject a gameGridProvider
            m_GameVictoryValidator = new HorizontalGameVictoryValidator();
        }

        [Test]
        public void TestVictoryDetected(GameGrid gameGrid)
        {
            var result = m_GameVictoryValidator.Validate(gameGrid);
        }

        [Test]
        // No player has won yet
        public void TestVictoryNotDetected(GameGrid gameGrid)
        {
            var result = m_GameVictoryValidator.Validate(gameGrid);
        }

        private void CreateGameGrid(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = new GameGrid(rows, columns);

            for (var i = 0; i < rows; i++)
            {
                if (!rowsToPopulate.Contains(i))
                    continue;

                for (var j = 0; j < columns; j++)
                {
                    if (columnsToPopulate.Contains(j))
                    {
                        gameGrid.Grid[i][j] = Players.Yellow;
                    }
                }
            }
        }
    }
}
