using System;
using System.Collections.Generic;
using System.Text;

namespace ECC.NET.Exceptions
{
	public class GreatestCommonDivisorException : Exception
	{
		public GreatestCommonDivisorException(string message) : base(message)
		{
		}
	}
}
