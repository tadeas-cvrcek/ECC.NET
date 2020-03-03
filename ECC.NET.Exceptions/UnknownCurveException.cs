using System;

namespace ECC.NET.Exceptions
{
	public class UnknownCurveException : Exception
	{
		public UnknownCurveException(string message) : base(message)
		{
		}
	}
}
