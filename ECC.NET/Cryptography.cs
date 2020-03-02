using System.Linq;
using System.Numerics;

namespace ECC.NET
{
	public static class Cryptography
	{
		public struct KeyPair
		{
			public BigInteger PrivateKey;
			public Point PublicKey;
		}

		public static KeyPair GetKeyPair(Curve curve)
		{
			KeyPair result = new KeyPair();
			uint keyBytes = curve.Length / 8;

			byte[] unsignedBytes = new byte[] { 0x00 };
			byte[] randomBytes = new byte[keyBytes];

			Commons.randomNumberGenerator.GetBytes(randomBytes);

			byte[] positiveRandomBytes = randomBytes.Concat(unsignedBytes).ToArray(); // To avoid randomBytes treated as negtive value
			BigInteger randomValue = new BigInteger(positiveRandomBytes);

			do
			{
				result.PrivateKey = (randomValue % curve.N);
			}
			while (result.PrivateKey == 0);


			result.PublicKey = Point.Multiply(result.PrivateKey, curve.G);
			return result;
		}

		public static Point GetSharedSecret(BigInteger privateKey, Point publicKey) => Point.Multiply(privateKey, publicKey);

	}
}
