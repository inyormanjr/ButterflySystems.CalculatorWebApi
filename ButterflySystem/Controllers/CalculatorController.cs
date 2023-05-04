using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ButterflySystems.Calculator.BLL;
using ButterflySystems.Calculator.BLL.Interfaces;
using ButterflySystems.CalculatorApi.DTO;
using Microsoft.AspNetCore.Mvc;


namespace ButterflySystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> logger;
        private readonly ICalculatorService calculatorService;

        public CalculatorController(ILogger<CalculatorController> logger,ICalculatorService calculatorService)
        {
            this.logger = logger;
            this.calculatorService = calculatorService;
        }
        [HttpPost("Add")]
        public IActionResult AddValues(decimal Addends1, decimal Addends2)
        {
            decimal result = this.calculatorService.Add(Addends1, Addends2);
            CalculatorResultDTO calculatorResultDTO = new CalculatorResultDTO(){
              Result = result
            };
            return Ok(calculatorResultDTO);
        }

        [HttpPost("Subtract")]
        public IActionResult SubtractValues(decimal minuend, decimal subtrahend)
        {
            decimal result = this.calculatorService.Subtract(minuend, subtrahend);
            CalculatorResultDTO calculatorResultDTO = new CalculatorResultDTO()
            {
                Result = result
            };
            return Ok(calculatorResultDTO);
        }

        [HttpPost("Multiply")]
        public IActionResult MultiplyValues(decimal multiplicand, decimal multiplier)
        {
            decimal result = this.calculatorService.Multiply(multiplicand, multiplier);
            CalculatorResultDTO calculatorResultDTO = new CalculatorResultDTO()
            {
                Result = result
            };
            return Ok(calculatorResultDTO);
        }

        [HttpPost("Divide")]
        public IActionResult DivideValues(decimal divident, decimal devisor)
        {
            decimal result = this.calculatorService.Divide(divident, devisor);
            CalculatorResultDTO calculatorResultDTO = new CalculatorResultDTO()
            {
                Result = result
            };
            return Ok(calculatorResultDTO);
        }
    }
}

