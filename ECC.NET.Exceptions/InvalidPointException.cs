using System;

namespace ECC.NET.Exceptions
{
	public class InvalidPointException : Exception
	{
		public InvalidPointException(string message) : base(message)
		{
		}
	}
}
