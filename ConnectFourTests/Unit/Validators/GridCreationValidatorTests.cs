using ConnectFour.Validators;
using NUnit.Framework;

namespace ConnectFourTests.Unit.Validators
{
    [TestFixture]
    public class GridCreationValidatorTests
    {
        private IGridCreationValidator m_GridCreationValidator;

        [SetUp]
        public void Setup()
        {
            m_GridCreationValidator = new GridCreationValidator();
        }

        [TestCase("5", "5")]
        [TestCase("6", "5")]
        [TestCase("5", "6")]
        [TestCase("6", "6")]
        [TestCase("6", "7")]
        public void TestValidGridSize(string rows, string columns)
        {
            var result = m_GridCreationValidator.Validate(rows, columns);
            Assert.IsTrue(result);
        }

        [TestCase("0", "5", Description = "Should fail, rows are too small")]
        [TestCase("5", "0", Description = "Should fail, columns are too small")]
        [TestCase("10", "5", Description = "Should fail, rows are too big")]
        [TestCase("5", "10", Description = "Should fail, columns are too big")]
        public void TestFailInvalidGridSize(string rows, string columns)
        {
            var result = m_GridCreationValidator.Validate(rows, columns);
            Assert.IsFalse(result);
        }

        [TestCase("!", "5", Description = "Should fail, rows is a special character")]
        [TestCase("5", "!", Description = "Should fail, columns is a special character")]
        [TestCase("A", "5", Description = "Should fail, rows is a letter")]
        [TestCase("5", "A", Description = "Should fail, columns is a letter")]
        public void TestFailInvalidInteger(string rows, string columns)
        {
            var result = m_GridCreationValidator.Validate(rows, columns);
            Assert.IsFalse(result);
        }
    }
}
