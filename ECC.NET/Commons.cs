using System.Security.Cryptography;

namespace ECC.NET
{
	/// <summary>
	/// Common objects to more ECC.NET classes.
	/// </summary>
	internal static class Commons
	{
		internal static RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
	}
}
