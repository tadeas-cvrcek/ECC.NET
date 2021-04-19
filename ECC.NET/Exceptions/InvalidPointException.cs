using System;

namespace ECC.NET.Exceptions
{
	/// <summary>
	/// Exception for point, which is not on appropriate curve.
	/// </summary>
	public class InvalidPointException : Exception
	{
		public InvalidPointException(string message) : base(message)
		{
		}
	}
}
