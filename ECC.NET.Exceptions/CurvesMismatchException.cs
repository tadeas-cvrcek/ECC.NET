using System;

namespace ECC.NET.Exceptions
{
	public class CurvesMismatchException : Exception
	{
		public CurvesMismatchException(string message) : base(message)
		{
		}
	}
}
