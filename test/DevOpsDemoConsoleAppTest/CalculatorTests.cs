
using DevOpsDemoConsoleApp;

namespace DevOpsDemoConsoleAppTest
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAdd()
        {
            var calculator = new Calculator();

            var result = calculator.Add(5, 5);

            Assert.Equal(10, result);
        }

        [Fact]
        public void TestMultiply()
        {
            var calculator = new Calculator();

            var result = calculator.Multiply(5, 5);

            Assert.Equal(25, result);
        }

    }
}