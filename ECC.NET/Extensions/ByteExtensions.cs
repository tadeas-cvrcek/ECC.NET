using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ECC.NET.Extensions
{
	public static class ByteExtensions
	{
		public static void Randomize(this byte[] input)
		{
			using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
			randomNumberGenerator.GetBytes(input);
		}
	}
}
