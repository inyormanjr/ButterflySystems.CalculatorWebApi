using ButterflySystems.Calculator.BLL.Exceptions;
using Xunit;


namespace ButterflySystems.Calculator.BLL.Tests
{
    public class CalculatorServiceTests
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorServiceTests()
        {
            _calculatorService = new CalculatorService();
        }

        [Fact]
        public void Add_ReturnsSumOfTwoNumbers()
        {
            // Arrange
            decimal num1 = 5.5m;
            decimal num2 = 6.5m;
            decimal expectedSum = 12m;

            // Act
            decimal actualSum = _calculatorService.Add(num1, num2);

            // Assert
            Assert.Equal(expectedSum, actualSum);
        }

        [Fact]
        public void Subtract_ReturnsDifferenceOfTwoNumbers()
        {
            // Arrange
            decimal minuend = 10m;
            decimal subtrahend = 2.5m;
            decimal expectedDifference = 7.5m;

            // Act
            decimal actualDifference = _calculatorService.Subtract(minuend, subtrahend);

            // Assert
            Assert.Equal(expectedDifference, actualDifference);
        }

        [Fact]
        public void Multiply_ReturnsProductOfTwoNumbers()
        {
            // Arrange
            decimal multiplicand = 5m;
            decimal multiplier = 3m;
            decimal expectedProduct = 15m;

            // Act
            decimal actualProduct = _calculatorService.Multiply(multiplicand, multiplier);

            // Assert
            Assert.Equal(expectedProduct, actualProduct);
        }

        [Fact]
        public void Divide_ReturnsQuotientOfTwoNumbers()
        {
            // Arrange
            decimal divident = 20m;
            decimal divisor = 5m;
            decimal expectedQuotient = 4m;

            // Act
            decimal actualQuotient = _calculatorService.Divide(divident, divisor);

            // Assert
            Assert.Equal(expectedQuotient, actualQuotient);
        }

        [Fact]
        public void Divide_ByZero_ThrowsSyntaxErrorException()
        {
            // Arrange
            decimal divident = 20m;
            decimal divisor = 0m;
            var expectedExceptionMessage = "Cannot be divided to zero.";

            // Act and Assert
            var ex = Assert.Throws<SyntaxErrorException>(() => _calculatorService.Divide(divident, divisor));
            Assert.Equal(expectedExceptionMessage, ex.Message);
        }
    }
}
