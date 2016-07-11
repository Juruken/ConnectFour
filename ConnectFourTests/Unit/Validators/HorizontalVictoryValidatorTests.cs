using System.Collections;
using System.Collections.Generic;
using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class HorizontalVictoryValidatorTests : BaseGameVictoryValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            // TODO: Determine if we want to inject a gameGridProvider
            m_GameVictoryValidator = new HorizontalGameVictoryValidator();
        }

        [Test, TestCaseSource(typeof(HorizontalVictoryTestDataProvider), "GetVictoryDetectedTestCases")]
        public void TestVictoryDetected(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate);

            var result = m_GameVictoryValidator.Validate(gameGrid, m_WinningPlayer);
            Assert.IsTrue(result);
        }

        [Test, TestCaseSource(typeof(HorizontalVictoryTestDataProvider), "GetVictoryDetectedTestCases")]
        public void TestVictoryNotDetectedForLosingPlayer(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate);
            var result = m_GameVictoryValidator.Validate(gameGrid, m_LosingPlayer);
            Assert.IsFalse(result);
        }

        [Test, TestCaseSource(typeof(HorizontalVictoryTestDataProvider), "GetVictoryNotDetectedTestCases")]
        public void TestVictoryNotDetected(int rows, int columns, List<int> rowsToPopulate, List<int> columnsToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate);
            var result = m_GameVictoryValidator.Validate(gameGrid, m_WinningPlayer);
            Assert.IsFalse(result);
        }
    }
}

public class HorizontalVictoryTestDataProvider
{
    private static List<int> columns0Through3 = new List<int> { 0, 1, 2, 3 };
    private static List<int> columns1Through4 = new List<int> { 1, 2, 3, 4 };

    public static IEnumerable GetVictoryDetectedTestCases
    {
        get
        {
            // TODO: UPDATE THIS... currently testing for VERTICAL VICTORY...not horizontal.
            // TODO: Make it test columns!
            yield return new TestCaseData(5, 5, new List<int> { 0 }, columns0Through3)
                .SetDescription("This should detect a victory in the first row for columns 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 0 }, columns1Through4)
                .SetDescription("This should detect a victory in the first row for columns 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 1 }, columns0Through3)
                .SetDescription("This should detect a victory in the second row for columns 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 1 }, columns1Through4)
                .SetDescription("This should detect a victory in the second row for columns 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 2}, columns0Through3)
                .SetDescription("This should detect a victory in the third row for columns 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 2}, columns1Through4)
                .SetDescription("This should detect a victory in the third row for columns 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 3}, columns0Through3)
                .SetDescription("This should detect a victory in the fourth row for columns 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 3 }, columns1Through4)
                .SetDescription("This should detect a victory in the fourth row for columns 1-4");

            yield return new TestCaseData(5, 5, new List<int> { 4 }, columns0Through3)
                .SetDescription("This should detect a victory in the fifth row for columns 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 4 }, columns1Through4)
                .SetDescription("This should detect a victory in the fifth row for columns 1-4");
        }
    }

    private static List<int> columns0Through2 = new List<int> { 0, 1, 2 };
    private static List<int> columns1Through3 = new List<int> { 1, 2, 3 };

    public static IEnumerable GetVictoryNotDetectedTestCases
    {
        get
        {
            yield return new TestCaseData(5, 5, new List<int> { 0 }, columns0Through2)
                .SetDescription("This should not detect a victory in the first column for rows 0-3");

            yield return new TestCaseData(5, 5, new List<int> { 0 }, columns1Through3)
                .SetDescription("This should not detect a victory in the first column for rows 0-3");
        }
    }
}