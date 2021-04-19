using System;

namespace ECC.NET.Exceptions
{
	/// <summary>
	/// Exception for point operations. Used when one of the points has different curve instance assigned.
	/// </summary>
	public class CurvesMismatchException : Exception
	{
		public CurvesMismatchException(string message) : base(message)
		{
		}
	}
}
