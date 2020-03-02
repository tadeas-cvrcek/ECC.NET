using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using ECC.NET;

namespace ECC.NET
{
	class Program
	{
		static string CalculateMD5Hash(string input)
		{
			// step 1, calculate MD5 hash from input
			MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);

			// step 2, convert byte array to hex string
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}
			return sb.ToString();
		}

		static void PrintValue(string valueName, object value)
		{
			Console.WriteLine(string.Concat(valueName, ": ", value));
		}

		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("SIMPLE TEST");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (Curve.Names curveName in (Curve.Names[])Enum.GetValues(typeof(Curve.Names)))
			{
				try
				{
					DateTime start = DateTime.Now;

					Curve curve = new Curve(curveName);
					BigInteger groupSource = curve.N;

					BigInteger a = Numerics.GetNumberFromGroup(groupSource, curve.Length);
					BigInteger b = Numerics.GetNumberFromGroup(groupSource, curve.Length);

					Point firstPoint = Point.Multiply(a + b, curve.G);
					Point secondPoint = Point.Add(Point.Multiply(a, curve.G), Point.Multiply(b, curve.G));

					DateTime finish = DateTime.Now;
					PrintValue($"{curveName.ToString()} passed", string.Concat(firstPoint.X == secondPoint.X && firstPoint.Y == secondPoint.Y, " (", (int)(finish - start).TotalMilliseconds, " ms)"));
				}
				catch (Exception exception)
				{
					PrintValue($"{curveName.ToString()} passed", string.Concat("Error (", exception.Message, ")"));
				}
			}

			Console.WriteLine();
			
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("AUTHENTICATION TEST (EXPERIMENTAL)");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (Curve.Names curveName in (Curve.Names[])Enum.GetValues(typeof(Curve.Names)))
			{
				try
				{
					DateTime start = DateTime.Now;

					Curve curve = new Curve(curveName);
					BigInteger groupSource = curve.N;

					BigInteger m = Numerics.GetNumberFromGroup(groupSource, curve.Length);
					BigInteger x0 = Numerics.GetNumberFromGroup(groupSource, curve.Length);

					Point sigma = Point.Multiply(Numerics.ModularInverse(BigInteger.Add(m, x0), groupSource), curve.G);

					BigInteger nonce = Numerics.GetNumberFromGroup(groupSource, curve.Length);

					BigInteger r = Numerics.GetNumberFromGroup(groupSource, curve.Length);
					BigInteger ro_r = Numerics.GetNumberFromGroup(groupSource, curve.Length);
					BigInteger ro_m = Numerics.GetNumberFromGroup(groupSource, curve.Length);

					Point sigma_A = Point.Multiply(r, sigma);
					Point t = Point.Add(Point.Multiply(ro_m, sigma_A), Point.Multiply(ro_r, curve.G));

					BigInteger e = BigInteger.Parse(CalculateMD5Hash(string.Concat(sigma_A, t, nonce)), System.Globalization.NumberStyles.HexNumber);
					BigInteger s_r = BigInteger.Add(ro_r, BigInteger.Multiply(e, r) % groupSource) % groupSource;
					BigInteger s_m = BigInteger.Subtract(ro_m, BigInteger.Multiply(e, m) % groupSource) % groupSource;

					Point t_alt = Point.Add(Point.Multiply(s_r, curve.G), Point.Multiply((s_m - ((e * x0) % groupSource) % groupSource), sigma_A));
					BigInteger e_alt = BigInteger.Parse(CalculateMD5Hash(string.Concat(sigma_A, t_alt, nonce)), System.Globalization.NumberStyles.HexNumber);

					DateTime finish = DateTime.Now;
					PrintValue($"{curveName.ToString()} passed", string.Concat(e == e_alt, " (", (int)(finish - start).TotalMilliseconds, " ms)"));
				}
				catch (Exception exception)
				{
					PrintValue($"{curveName.ToString()} passed", string.Concat("Error (", exception.Message, ")"));
				}
			}

			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("ECDH TEST");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (Curve.Names curveName in (Curve.Names[])Enum.GetValues(typeof(Curve.Names)))
			{
				try
				{
					DateTime start = DateTime.Now;

					Curve curve = new Curve(curveName);

					Cryptography.KeyPair aliceKeyPair = Cryptography.GetKeyPair(curve);
					Cryptography.KeyPair bobKeyPair = Cryptography.GetKeyPair(curve);

					Point aliceSharedSecret = Cryptography.GetSharedSecret(aliceKeyPair.PrivateKey, bobKeyPair.PublicKey);
					Point bobSharedSecret = Cryptography.GetSharedSecret(bobKeyPair.PrivateKey, aliceKeyPair.PublicKey);

					DateTime finish = DateTime.Now;
					PrintValue($"{curveName.ToString()} passed", string.Concat(aliceSharedSecret.X == bobSharedSecret.X && aliceSharedSecret.Y == bobSharedSecret.Y, " (", (int)(finish - start).TotalMilliseconds, " ms)"));
				}
				catch (Exception exception)
				{
					PrintValue($"{curveName.ToString()} passed", string.Concat("Error (", exception.Message, ")"));
				}
			}

			Console.WriteLine();
			Console.ReadLine();
		}
	}
}
