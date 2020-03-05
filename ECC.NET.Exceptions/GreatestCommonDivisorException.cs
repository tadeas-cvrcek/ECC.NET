using System;

namespace ECC.NET.Exceptions
{
	/// <summary>
	/// Exception for unwanted greatest common divisor value or an error during computation of it.
	/// </summary>
	public class GreatestCommonDivisorException : Exception
	{
		public GreatestCommonDivisorException(string message) : base(message)
		{
		}
	}
}
