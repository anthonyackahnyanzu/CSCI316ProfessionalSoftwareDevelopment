using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Module11_UnitTesting.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            int result = calc.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result);
        }
    }
}
