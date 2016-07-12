using System.Collections;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class MoveValidatorTests : BaseGameTests
    {
        private IMoveValidator m_MoveValidator;

        [SetUp]
        public void Setup()
        {
            m_MoveValidator = new MoveValidator();
        }

        [Test, TestCaseSource(typeof(MoveValidatorTestProvider), "MoveValidatorTestCases")]
        public void TestValidMove(int rows, int columns, int columnToPick, bool expectedResult,
            List<int> rowsToPopulate, List<int> columnsToPopulate, Players player)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowsToPopulate, columnsToPopulate, player);

            Assert.AreEqual(expectedResult, m_MoveValidator.Validate(gameGrid, columnToPick));
        }
    }
}


public class MoveValidatorTestProvider
{
    public static IEnumerable MoveValidatorTestCases
    {
        get
        {
            // Valid Moves - Empty Grid
            yield return new TestCaseData(5, 5, 0, true, new List<int> { }, new List<int> { }, Players.None).SetDescription("This move should be valid");
            yield return new TestCaseData(5, 5, 1, true, new List<int> { }, new List<int> { }, Players.None).SetDescription("This move should be valid");
            yield return new TestCaseData(5, 5, 2, true, new List<int> { }, new List<int> { }, Players.None).SetDescription("This move should be valid");
            yield return new TestCaseData(5, 5, 3, true, new List<int> { }, new List<int> { }, Players.None).SetDescription("This move should be valid");
            yield return new TestCaseData(5, 5, 4, true, new List<int> { }, new List<int> { }, Players.None).SetDescription("This move should be valid");

            // Invalid Moves - Full Grid
            yield return new TestCaseData(5, 5, 0, false, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4 }, Players.Red).SetDescription("This move should be invalid");
            yield return new TestCaseData(5, 5, 1, false, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4 }, Players.Red).SetDescription("This move should be invalid");
            yield return new TestCaseData(5, 5, 2, false, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4 }, Players.Red).SetDescription("This move should be invalid");
            yield return new TestCaseData(5, 5, 3, false, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4 }, Players.Red).SetDescription("This move should be invalid");
            yield return new TestCaseData(5, 5, 4, false, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4 }, Players.Red).SetDescription("This move should be invalid");
        }
    }
}