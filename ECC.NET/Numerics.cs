using ECC.NET.Exceptions;
using System;
using System.Numerics;

namespace ECC.NET
{
	public static class Numerics
	{
		public static bool IsProbablyPrime(BigInteger value, uint witnesses = 10)
		{
			if (value <= 1)
				throw new ArgumentException("Minimum number of witnesses is 2.");

			BigInteger d = value - 1;
			int s = 0;

			while (d % 2 == 0)
			{
				d /= 2;
				s += 1;
			}

			byte[] bytes = new byte[value.ToByteArray().LongLength];
			BigInteger a;

			for (int i = 0; i < witnesses; i++)
			{
				do
				{
					Commons.randomNumberGenerator.GetBytes(bytes);

					a = new BigInteger(bytes);
				}
				while (a < 2 || a >= value - 2);

				BigInteger x = BigInteger.ModPow(a, d, value);
				if (x == 1 || x == value - 1)
					continue;

				for (int r = 1; r < s; r++)
				{
					x = BigInteger.ModPow(x, 2, value);

					if (x == 1)
						return false;
					if (x == value - 1)
						break;
				}

				if (x != value - 1)
					return false;
			}

			return true;
		}

		public static BigInteger Modulus(BigInteger value, BigInteger modulus)
		{
			BigInteger reminder = value % modulus;

			return reminder < 0 ? reminder += modulus : reminder;
		}

		public static BigInteger ModularInverse(BigInteger value, BigInteger modulus)
		{
			if (value == 0)
				throw new DivideByZeroException();

			if (value < 0)
				return modulus - ModularInverse(-value, modulus);

			BigInteger a = 0, oldA = 1;
			BigInteger b = modulus, oldB = value;

			while (b != 0)
			{
				BigInteger quotient = oldB / b;

				BigInteger prov = b;
				b = oldB - quotient * prov;
				oldB = prov;

				prov = a;
				a = oldA - quotient * prov;
				oldA = prov;
			}

			BigInteger gcd = oldB;
			BigInteger c = oldA;

			if (gcd != 1)
				throw new GreatestCommonDivisorException($"GCD is not 1, but {gcd}.");

			if (Modulus(value * c, modulus) != 1)
				throw new ArithmeticException("Modular inverse final check failed.");

			return Modulus(c, modulus);
		}

		/// <summary>
		/// Generates random number of specified length (in bits).
		/// </summary>
		/// <param name="length">Length of number in bits.</param>
		/// <returns></returns>
		public static BigInteger GetNumber(uint length)
		{
			byte[] randomOutput = new byte[length];
			Commons.randomNumberGenerator.GetBytes(randomOutput);

			return new BigInteger(randomOutput);
		}

		/// <summary>
		/// Generates random number which belongs to multiplicative group defined by modulus parameter. Uses brute-force algorithm.
		/// </summary>
		/// <param name="modulus">Multipliative group definiction.</param>
		/// <param name="length">Length of number in bits.</param>
		/// <returns></returns>
		public static BigInteger GetNumberFromGroup(BigInteger modulus, uint length)
		{
			BigInteger result = 1;
			length /= 8;

			do
			{
				result = GetNumber(length) % modulus;

				if (result < 0)
					result += modulus;

			} while (BigInteger.GreatestCommonDivisor(result, modulus) != 1);

			return result;
		}
	}
}
