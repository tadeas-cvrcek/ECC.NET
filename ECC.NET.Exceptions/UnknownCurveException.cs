using System;
using System.Collections.Generic;
using System.Text;

namespace ECC.NET.Exceptions
{
	public class UnknownCurveException : Exception
	{
		public UnknownCurveException(string message) : base(message)
		{
		}
	}
}
