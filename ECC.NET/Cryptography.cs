using System.Linq;
using System.Numerics;

namespace ECC.NET
{
	/// <summary>
	/// Cryptographic functions using elliptic-curves.
	/// </summary>
	public static class Cryptography
	{
		public struct KeyPair
		{
			public BigInteger PrivateKey;
			public Point PublicKey;
		}

		/// <summary>
		/// Generates a pair of keys.
		/// </summary>
		/// <param name="curve">Curve to generate a pair of keys on.</param>
		/// <returns></returns>
		public static KeyPair GetKeyPair(Curve curve)
		{
			KeyPair result = new KeyPair();
			uint keyBytes = curve.Length / 8;

			byte[] unsignedBytes = new byte[] { 0x00 };
			byte[] randomBytes = new byte[keyBytes];

			Commons.randomNumberGenerator.GetBytes(randomBytes);

			byte[] positiveRandomBytes = randomBytes.Concat(unsignedBytes).ToArray();
			BigInteger randomValue = new BigInteger(positiveRandomBytes);

			do
			{
				result.PrivateKey = (randomValue % curve.N);
			}
			while (result.PrivateKey == 0);


			result.PublicKey = Point.Multiply(result.PrivateKey, curve.G);
			return result;
		}

		/// <summary>
		/// Derives shared secret of two entities.
		/// </summary>
		/// <param name="privateKey">Own private key.</param>
		/// <param name="publicKey">Foreign public key.</param>
		/// <returns></returns>
		public static Point GetSharedSecret(BigInteger privateKey, Point publicKey) => Point.Multiply(privateKey, publicKey);

	}
}
