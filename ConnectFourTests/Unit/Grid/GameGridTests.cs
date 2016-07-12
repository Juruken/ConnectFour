using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;
using ConnectFour.Constants;
using ConnectFour.DataModel;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Grid
{
    [TestFixture]
    public class GameGridTests : BaseGameTests
    {
        [TestCase(5, 5)]
        [TestCase(5, 6)]
        [TestCase(6, 5)]
        [TestCase(6, 6)]
        [TestCase(6, 7)]
        public void TestGameGridSize(int rows, int columns)
        {
            var gameGrid = new GameGrid(rows, columns);

            Assert.AreEqual(rows, gameGrid.Grid.Length);

            foreach (var row in gameGrid.Grid)
            {
                Assert.AreEqual(columns, row.Length);
            }
        }

        [TestCase(5, 5)]
        [TestCase(5, 6)]
        [TestCase(6, 5)]
        [TestCase(6, 6)]
        [TestCase(6, 7)]
        public void TestGameGridInitalisation(int rows, int columns)
        {
            var gameGrid = new GameGrid(rows, columns);

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var value = gameGrid.Grid[i][j];
                    Assert.AreEqual(Players.None, value);
                }
            }
        }

        [TestCase(5, 5, 1, 0)]
        [TestCase(5, 5, 1, 1)]
        [TestCase(5, 5, 1, 2)]
        [TestCase(5, 5, 1, 3)]
        [TestCase(5, 5, 1, 4)]
        public void TestAddToken(int rows, int columns, int countersToAdd, int columnToPick)
        {
            var gameGrid = CreateGameGrid(rows, columns, new EditableList<Tuple<int, int>>());

            for (int i = 0; i < countersToAdd; i++)
            {
                Assert.AreEqual(Players.None, gameGrid.Grid[i][columnToPick]);

                gameGrid.AddToken(columnToPick, Players.Yellow);

                Assert.AreEqual(Players.Yellow, gameGrid.Grid[i][columnToPick]);
            }
        }

        [TestCase(5, 5, 1, 0)]
        [TestCase(5, 5, 1, 1)]
        [TestCase(5, 5, 1, 2)]
        [TestCase(5, 5, 1, 3)]
        [TestCase(5, 5, 1, 4)]
        public void TestErrorOnAddToken(int rows, int columns, int countersToAdd, int columnToPick)
        {
            var gameGrid = CreateGameGrid(rows, columns, new List<int>() { 0, 1, 2, 3, 4 }, new List<int>() { 0, 1, 2, 3, 4 }, Players.Yellow);

            for (int i = 0; i < countersToAdd; i++)
            {
                Assert.That(() => gameGrid.AddToken(columnToPick, Players.Yellow), Throws.ArgumentException);
            }
        }
    }
}
