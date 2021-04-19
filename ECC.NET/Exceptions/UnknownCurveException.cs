using System;

namespace ECC.NET.Exceptions
{
	/// <summary>
	/// Exception for usage of unknown elliptic-curve name.
	/// </summary>
	public class UnknownCurveException : Exception
	{
		public UnknownCurveException(string message) : base(message)
		{
		}
	}
}
