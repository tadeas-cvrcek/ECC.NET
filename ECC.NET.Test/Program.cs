using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace ECC.NET
{
	class Program
	{
		static void PrintValue(string valueName, object value)
		{
			Console.WriteLine(string.Concat(valueName, ": ", value));
		}

		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("ADDITION TEST");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (Curve.CurveName curveName in (Curve.CurveName[])Enum.GetValues(typeof(Curve.CurveName)))
			{
				try
				{
					DateTime start = DateTime.Now;

					Curve curve = new Curve(curveName);
					Point firstPoint = Point.Add(curve.G, curve.G);

					DateTime finish = DateTime.Now;

					Point secondPoint = Point.Multiply(2, curve.G);

					PrintValue($"{curveName.ToString()} passed", string.Concat(firstPoint.X == secondPoint.X && firstPoint.Y == secondPoint.Y, " (", (int)(finish - start).TotalMilliseconds, " ms)"));
				}
				catch (Exception exception)
				{
					PrintValue($"{curveName.ToString()} passed", string.Concat("Error (", exception.Message, ")"));
				}
			}

			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("MULTIPLICATION TEST");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (Curve.CurveName curveName in (Curve.CurveName[])Enum.GetValues(typeof(Curve.CurveName)))
			{
				try
				{
					DateTime start = DateTime.Now;

					Curve curve = new Curve(curveName);

					int multiplier = 128;
					Point firstPoint = Point.Multiply(multiplier, curve.G);

					DateTime finish = DateTime.Now;

					Point secondPoint = curve.G;
					for (int i = 1; i < multiplier; i++)
						secondPoint = Point.Add(secondPoint, curve.G);

					PrintValue($"{curveName.ToString()} passed", string.Concat(firstPoint.X == secondPoint.X && firstPoint.Y == secondPoint.Y, " (", (int)(finish - start).TotalMilliseconds, " ms)"));
				}
				catch (Exception exception)
				{
					PrintValue($"{curveName.ToString()} passed", string.Concat("Error (", exception.Message, ")"));
				}
			}

			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("COMBINED EQUATION TEST");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (Curve.CurveName curveName in (Curve.CurveName[])Enum.GetValues(typeof(Curve.CurveName)))
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
			Console.WriteLine("ECDH TEST");
			Console.ForegroundColor = ConsoleColor.White;

			foreach (Curve.CurveName curveName in (Curve.CurveName[])Enum.GetValues(typeof(Curve.CurveName)))
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
