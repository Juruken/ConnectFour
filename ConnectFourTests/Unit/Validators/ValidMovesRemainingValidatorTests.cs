using System;
using System.Collections.Generic;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class ValidMovesRemainingValidatorTests : BaseGameVictoryValidatorTests
    {
        [SetUp]
        public void Setup()
        {
            m_GameVictoryValidator = new ValidMovesRemainingValidator();
        }

        [Test]
        public void TestInvalidPlayerException()
        {
            var gameGrid = new GameGrid(5, 5);
            Assert.That(() => m_GameVictoryValidator.Validate(gameGrid, Players.Red), Throws.ArgumentException);
            Assert.That(() => m_GameVictoryValidator.Validate(gameGrid, Players.Yellow), Throws.ArgumentException);
        }

        [Test]
        public void TestNoValidMoves()
        {
            var gameGrid = CreateGameGrid(5, 5, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4 }, m_WinningPlayer);
            var result = m_GameVictoryValidator.Validate(gameGrid, Players.None);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestValidMovesRemaining()
        {
            var gameGrid = CreateGameGrid(5, 5, new List<int> { 0, 1, 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4 });
            var result = m_GameVictoryValidator.Validate(gameGrid, Players.None);
            Assert.IsTrue(result);
        }
    }
}
