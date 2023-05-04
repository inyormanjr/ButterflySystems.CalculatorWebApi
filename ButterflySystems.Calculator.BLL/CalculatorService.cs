using ButterflySystems.Calculator.BLL.Exceptions;
using ButterflySystems.Calculator.BLL.Interfaces;

namespace ButterflySystems.Calculator.BLL;
public class CalculatorService:ICalculatorService
{
    public CalculatorService() { }

    public decimal Add(decimal Addends1, decimal Addends2)
    {
        return Addends1 + Addends2;
    }

    public decimal Subtract(decimal minuend, decimal subtrahend)
    {
        return minuend - subtrahend;
    }

    public decimal Multiply(decimal multiplicand, decimal multiplier)
    {
        return multiplicand * multiplier;
    }

    public decimal Divide(decimal divident, decimal devisor)
    {
        if (devisor == 0)
            throw new SyntaxErrorException("Cannot be divided to zero.");
        return divident / devisor;
    }

}

