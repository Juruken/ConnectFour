using ConnectFour.Constants;
using ConnectFour.DataModel;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Grid
{
    [TestFixture]
    public class GameGridTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

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
    }
}
