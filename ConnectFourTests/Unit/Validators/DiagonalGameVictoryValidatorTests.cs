using System;
using System.Collections;
using System.Collections.Generic;
using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class DiagonalGameVictoryValidatorTests : BaseGameVictoryValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_GameVictoryValidator = new DiagonalGameVictoryValidator();
        }

        [Test, TestCaseSource(typeof(DiagonalDownAndRightVictoryTestDataProvider), "GetVictoryDetectedTestCases")]
        public void TestVictoryDetectedDownAndRight(int rows, int columns, List<Tuple<int,int>> rowColumnToPopulate)
        {
            var gameGrid = CreateGameGrid(rows, columns, rowColumnToPopulate);
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
            yield return new TestCaseData(5, 5, new List<Tuple<int,int>>
            {
                new Tuple<int, int>(0, 0),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 3)
            }).SetDescription("This should detect a victory in diagonally from 0, 0 to 3, 3");

            yield return new TestCaseData(5, 5, new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(2, 2),
                new Tuple<int, int>(3, 3),
                new Tuple<int, int>(4, 4)
            }).SetDescription("This should detect a victory in diagonally from 1, 1 to 4, 4");

            yield return new TestCaseData(5, 5, new List<Tuple<int, int>>
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(3, 4)
            }).SetDescription("This should detect a victory in diagonally from 0, 1 to 3, 4");

            yield return new TestCaseData(5, 5, new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(2, 1),
                new Tuple<int, int>(3, 2),
                new Tuple<int, int>(4, 3)
            }).SetDescription("This should detect a victory in diagonally from 1, 0 to 4, 3");
        }
    }
}
