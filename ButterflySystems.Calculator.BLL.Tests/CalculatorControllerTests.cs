using ButterflySystem.Controllers;
using ButterflySystems.Calculator.BLL;
using ButterflySystems.Calculator.BLL.Interfaces;
using ButterflySystems.CalculatorApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace ButterflySystem.Tests
{
    public class CalculatorControllerTests
    {
        private readonly CalculatorController _calculatorController;
        private readonly Mock<ILogger<CalculatorController>> _loggerMock;
        private readonly Mock<ICalculatorService> _calculatorServiceMock;

        public CalculatorControllerTests()
        {
            _loggerMock = new Mock<ILogger<CalculatorController>>();
            _calculatorServiceMock = new Mock<ICalculatorService>();
            _calculatorController = new CalculatorController(_loggerMock.Object, _calculatorServiceMock.Object);
        }

        [Fact]
        public void AddValues_Should_Return_The_Sum_Of_Two_Numbers()
        {
            //Arrange
            var expected = new CalculatorResultDTO { Result = 10 };
            _calculatorServiceMock.Setup(x => x.Add(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(10);

            //Act
            var result = _calculatorController.AddValues(5, 5) as OkObjectResult;
            var actual = result?.Value as CalculatorResultDTO;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(actual);
            Assert.Equal(expected.Result, actual.Result);
        }

        [Fact]
        public void SubtractValues_Should_Return_The_Difference_Of_Two_Numbers()
        {
            //Arrange
            var expected = new CalculatorResultDTO { Result = 5 };
            _calculatorServiceMock.Setup(x => x.Subtract(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(5);

            //Act
            var result = _calculatorController.SubtractValues(10, 5) as OkObjectResult;
            var actual = result?.Value as CalculatorResultDTO;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(actual);
            Assert.Equal(expected.Result, actual.Result);
        }

        [Fact]
        public void MultiplyValues_Should_Return_The_Product_Of_Two_Numbers()
        {
            //Arrange
            var expected = new CalculatorResultDTO { Result = 50 };
            _calculatorServiceMock.Setup(x => x.Multiply(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(50);

            //Act
            var result = _calculatorController.MultiplyValues(10, 5) as OkObjectResult;
            var actual = result?.Value as CalculatorResultDTO;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(actual);
            Assert.Equal(expected.Result, actual.Result);
        }

        [Fact]
        public void DivideValues_Should_Return_The_Quotient_Of_Two_Numbers()
        {
            //Arrange
            var expected = new CalculatorResultDTO { Result = 2 };
            _calculatorServiceMock.Setup(x => x.Divide(It.IsAny<decimal>(), It.IsAny<decimal>())).Returns(2);

            //Act
            var result = _calculatorController.DivideValues(10, 5) as OkObjectResult;
            var actual = result?.Value as CalculatorResultDTO;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(actual);
            Assert.Equal(expected.Result, actual.Result);
        }
    }
}
