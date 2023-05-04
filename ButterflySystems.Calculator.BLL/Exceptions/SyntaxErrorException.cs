using System;
namespace ButterflySystems.Calculator.BLL.Exceptions
{
	public class SyntaxErrorException: Exception
	{
		public SyntaxErrorException(String Message):base(message: Message)
		{
		}
	}
}

