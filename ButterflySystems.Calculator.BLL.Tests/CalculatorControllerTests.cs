using ButterflySystem.Controllers;
using ButterflySystems.Calculator.BLL.Exceptions;
using ButterflySystems.Calculator.BLL.Interfaces;
using ButterflySystems.CalculatorApi.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ButterflySystem.Tests.Controllers
{
    public class CalculatorControllerTests
    {
        [Fact]
        public void AddValues_ReturnsOk()
        {
            // Arrange
            decimal addends1 = 5.5m;
            decimal addends2 = 2.5m;
            decimal expected = 8m;
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Add(addends1, addends2)).Returns(expected);
            var controller = new CalculatorController(mockCalculatorService.Object);

            // Act
            var result = controller.AddValues(addends1, addends2);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var calculatorResultDTO = Assert.IsType<CalculatorResultDTO>(okObjectResult.Value);
            Assert.Equal(expected, calculatorResultDTO.Result);
        }

        [Fact]
        public void SubtractValues_ReturnsOk()
        {
            // Arrange
            decimal minuend = 10m;
            decimal subtrahend = 5m;
            decimal expected = 5m;
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Subtract(minuend, subtrahend)).Returns(expected);
            var controller = new CalculatorController(mockCalculatorService.Object);

            // Act
            var result = controller.SubtractValues(minuend, subtrahend);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var calculatorResultDTO = Assert.IsType<CalculatorResultDTO>(okObjectResult.Value);
            Assert.Equal(expected, calculatorResultDTO.Result);
        }

        [Fact]
        public void MultiplyValues_ReturnsOk()
        {
            // Arrange
            decimal multiplicand = 10m;
            decimal multiplier = 5m;
            decimal expected = 50m;
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Multiply(multiplicand, multiplier)).Returns(expected);
            var controller = new CalculatorController(mockCalculatorService.Object);

            // Act
            var result = controller.MultiplyValues(multiplicand, multiplier);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var calculatorResultDTO = Assert.IsType<CalculatorResultDTO>(okObjectResult.Value);
            Assert.Equal(expected, calculatorResultDTO.Result);
        }

        [Fact]
        public void DivideValues_ReturnsOk()
        {
            //Arrange
            decimal divident = 10m;
            decimal devisor = 5m;
            decimal expected = 2m;
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(divident, devisor)).Returns(expected);
            var controller = new CalculatorController(mockCalculatorService.Object);

            //Act
            var result = controller.DivideValues(divident, devisor);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var calcultorResultDTO = Assert.IsType<CalculatorResultDTO>(okObjectResult.Value);
            Assert.Equal(expected, calcultorResultDTO.Result);
        }

        [Fact]
        public void DivideValues_DivisorIsZero_ThrowsSyntaxErrorException()
        {
            // Arrange
            decimal dividend = 10m;
            decimal divisor = 0m;
            var mockCalculatorService = new Mock<ICalculatorService>();
            mockCalculatorService.Setup(x => x.Divide(dividend, divisor)).Throws(new SyntaxErrorException("Cannot be divided to zero."));
            var controller = new CalculatorController(mockCalculatorService.Object);

            // Act
            var ex = Assert.Throws<SyntaxErrorException>(() => controller.DivideValues(dividend, divisor));

            // Assert
            Assert.Equal("Cannot be divided to zero.", ex.Message);
        }
    }
}
