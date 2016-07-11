using System.Collections;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class VerticalVictoryValidatorTests
    {
        private IGameVictoryValidator m_GameVictoryValidator;
        private Players m_WinningPlayer = Players.Yellow;
        private Players m_LosingPlayer = Players.Red;

        [SetUp]
        public void Setup()
        {
            // TODO: Determine if we want to inject a gameGridProvider
            m_GameVictoryValidator = new VerticalGameVictoryValidator();
        }

        [Test, TestCaseSource(typeof(VerticalVictoryTestDataProvider), "GetVictoryDetectedTestCases")]
        public void TestVictoryDetected(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate);
            var result = m_GameVictoryValidator.Validate(gameGrid, m_WinningPlayer);
            Assert.IsTrue(result);
        }

        [Test, TestCaseSource(typeof(VerticalVictoryTestDataProvider), "GetVictoryDetectedTestCases")]
        public void TestVictoryNotDetectedForLosingPlayer(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate);
            var result = m_GameVictoryValidator.Validate(gameGrid, m_LosingPlayer);
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(VerticalVictoryTestDataProvider), "GetVictoryNotDetectedTestCases")]
        public void TestVictoryNotDetected(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate);
            var result = m_GameVictoryValidator.Validate(gameGrid, m_WinningPlayer);
            Assert.IsFalse(result);
        }

        private GameGrid CreateGameGrid(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
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
                        gameGrid.Grid[i][j] = m_WinningPlayer;
                    }
                }
            }

            return gameGrid;
        }
    }
}

public class VerticalVictoryTestDataProvider
{
    public static IEnumerable GetVictoryDetectedTestCases
    {
        get
        {
            yield return new TestCaseData(5, 5, new List<int> { 0, 1, 2, 3 }, new List<int> { 0 })
                .SetDescription("This should detect a victory in the first column for rows 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 1, 2, 3, 4}, new List<int> { 0 })
                .SetDescription("This should detect a victory in the first column for rows 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 0, 1, 2, 3 }, new List<int> { 1 })
                .SetDescription("This should detect a victory in the second column for rows 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 0, 1, 2, 3 }, new List<int> { 1 })
                .SetDescription("This should detect a victory in the second column for rows 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 0, 1, 2, 3 }, new List<int> { 2 })
                .SetDescription("This should detect a victory in the third column for rows 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 1, 2, 3, 4 }, new List<int> { 2 })
                .SetDescription("This should detect a victory in the third column for rows 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 0, 1, 2, 3 }, new List<int> { 3 })
                .SetDescription("This should detect a victory in the fourth column for rows 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 1, 2, 3, 4 }, new List<int> { 3 })
                .SetDescription("This should detect a victory in the fourth column for rows 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 0, 1, 2, 3 }, new List<int> { 4 })
                .SetDescription("This should detect a victory in the fifth column for rows 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 1, 2, 3, 4 }, new List<int> { 4 })
                .SetDescription("This should detect a victory in the fifth column for rows 1-4");
        }
    }

    public static IEnumerable GetVictoryNotDetectedTestCases
    {
        get
        {
            yield return new TestCaseData(5, 5, new List<int> { 0, 1, 2 }, new List<int> { 0 })
                .SetDescription("This should not detect a victory in the first column for rows 0-3");
        }
    }
}