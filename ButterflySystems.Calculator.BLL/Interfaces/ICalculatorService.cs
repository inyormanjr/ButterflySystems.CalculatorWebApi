using System;
namespace ButterflySystems.Calculator.BLL.Interfaces
{
	public interface ICalculatorService
	{

        public decimal Add(decimal val1, decimal val2);

        public decimal Subtract(decimal val1, decimal val2);

        public decimal Multiply(decimal val1, decimal val2);

        public decimal Divide(decimal val1, decimal val2);
    }
}

