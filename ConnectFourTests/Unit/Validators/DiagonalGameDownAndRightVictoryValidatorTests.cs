using System.Collections;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class DiagonalGameDownAndRightVictoryValidatorTests : BaseGameVictoryValidatorTests
    {
        private IGameVictoryValidator m_GameVictoryValidator;
        private Players m_WinningPlayer = Players.Yellow;
        private Players m_LosingPlayer = Players.Red;

        [SetUp]
        public void Setup()
        {
            m_GameVictoryValidator = new DiagonalGameVictoryValidator();
        }

        [Test, TestCaseSource(typeof(DiagonalDownAndRightVictoryTestDataProvider), "GetVictoryDetectedTestCases")]
        public void TestVictoryDetectedDownAndRight(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate);
            var result = m_GameVictoryValidator.Validate(gameGrid, m_WinningPlayer);
            Assert.IsTrue(result);
        }
    }
}

public class DiagonalDownAndRightVictoryTestDataProvider
{
    public static IEnumerable GetVictoryDetectedTestCases
    {
        get
        {
            yield return new TestCaseData()
                .SetDescription("");
        }
    }
}
