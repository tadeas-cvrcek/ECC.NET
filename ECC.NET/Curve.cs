using ECC.NET.Exceptions;
using System;
using System.Globalization;
using System.Numerics;

namespace ECC.NET
{
	/// <summary>
	/// ECC.NET elliptic-curve class.
	/// </summary>
	public class Curve
	{
		public enum Names
		{
			secp160r1,
			secp160r2,
			secp160k1,
			secp192r1,
			secp192k1,
			secp224r1,
			secp224k1,
			secp256r1,
			secp256k1
		}

		public Names? Name { get; private set; }
		public BigInteger P { get; private set; }
		public BigInteger A { get; private set; }
		public BigInteger B { get; private set; }
		public Point G { get; private set; }
		public BigInteger N { get; private set; }
		public short H { get; private set; }
		public uint Length { get; private set; }

		/// <summary>
		/// Creates known elliptic-curve instance by given name.
		/// </summary>
		/// <param name="name">Name of target curve.</param>
		public Curve(Names name)
		{
			switch (name)
			{
				case Names.secp160r1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF7FFFFFFF", NumberStyles.HexNumber);

						A = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF7FFFFFFC", NumberStyles.HexNumber);
						B = BigInteger.Parse("001C97BEFC54BD7A8B65ACF89F81D4D4ADC565FA45", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("004A96B5688EF573284664698968C38BB913CBFC82", NumberStyles.HexNumber), BigInteger.Parse("0023A628553168947D59DCC912042351377AC5FB32", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("0000000000000000000001F4C8F927AED3CA752257", NumberStyles.HexNumber);
						H = 1;

						Length = 160;
					}
					break;
				case Names.secp160r2:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFAC73", NumberStyles.HexNumber);

						A = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFAC70", NumberStyles.HexNumber);
						B = BigInteger.Parse("00B4E134D3FB59EB8BAB57274904664D5AF50388BA", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("0052DCB034293A117E1F4FF11B30F7199D3144CE6D", NumberStyles.HexNumber), BigInteger.Parse("00FEAFFEF2E331F296E071FA0DF9982CFEA7D43F2E", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("0000000000000000000000351EE786A818F3A1A16B", NumberStyles.HexNumber);
						H = 1;

						Length = 160;
					}
					break;
				case Names.secp160k1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFAC73", NumberStyles.HexNumber);

						A = BigInteger.Parse("000000000000000000000000000000000000000000", NumberStyles.HexNumber);
						B = BigInteger.Parse("000000000000000000000000000000000000000007", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("003B4C382CE37AA192A4019E763036F4F5DD4D7EBB", NumberStyles.HexNumber), BigInteger.Parse("00938CF935318FDCED6BC28286531733C3F03C4FEE", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("0000000000000000000001B8FA16DFAB9ACA16B6B3", NumberStyles.HexNumber);
						H = 1;

						Length = 160;
					}
					break;
				case Names.secp192r1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFF", NumberStyles.HexNumber);

						A = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFC", NumberStyles.HexNumber);
						B = BigInteger.Parse("0064210519E59C80E70FA7E9AB72243049FEB8DEECC146B9B1", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00188DA80EB03090F67CBF20EB43A18800F4FF0AFD82FF1012", NumberStyles.HexNumber), BigInteger.Parse("0007192B95FFC8DA78631011ED6B24CDD573F977A11E794811", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFF99DEF836146BC9B1B4D22831", NumberStyles.HexNumber);
						H = 1;

						Length = 192;
					}
					break;
				case Names.secp192k1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFEE37", NumberStyles.HexNumber);

						A = BigInteger.Parse("00000000000000000000000000000000000000000000000000", NumberStyles.HexNumber);
						B = BigInteger.Parse("00000000000000000000000000000000000000000000000003", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00DB4FF10EC057E9AE26B07D0280B7F4341DA5D1B1EAE06C7D", NumberStyles.HexNumber), BigInteger.Parse("009B2F2F6D9C5628A7844163D015BE86344082AA88D95E2F9D", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFE26F2FC170F69466A74DEFD8D", NumberStyles.HexNumber);
						H = 1;

						Length = 192;
					}
					break;
				case Names.secp224r1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF000000000000000000000001", NumberStyles.HexNumber);

						A = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFE", NumberStyles.HexNumber);
						B = BigInteger.Parse("00B4050A850C04B3ABF54132565044B0B7D7BFD8BA270B39432355FFB4", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00B70E0CBD6BB4BF7F321390B94A03C1D356C21122343280D6115C1D21", NumberStyles.HexNumber), BigInteger.Parse("00BD376388B5F723FB4C22DFE6CD4375A05A07476444D5819985007E34", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFF16A2E0B8F03E13DD29455C5C2A3D", NumberStyles.HexNumber);
						H = 1;

						Length = 224;
					}
					break;
				case Names.secp224k1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFE56D", NumberStyles.HexNumber);

						A = BigInteger.Parse("0000000000000000000000000000000000000000000000000000000000", NumberStyles.HexNumber);
						B = BigInteger.Parse("0000000000000000000000000000000000000000000000000000000005", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00A1455B334DF099DF30FC28A169A467E9E47075A90F7E650EB6B7A45C", NumberStyles.HexNumber), BigInteger.Parse("007E089FED7FBA344282CAFBD6F7E319F7C0B0BD59E2CA4BDB556D61A5", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("000000000000000000000000000001DCE8D2EC6184CAF0A971769FB1F7", NumberStyles.HexNumber);
						H = 1;

						Length = 224;
					}
					break;
				case Names.secp256r1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFF", NumberStyles.HexNumber);

						A = BigInteger.Parse("00FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFC", NumberStyles.HexNumber);
						B = BigInteger.Parse("005AC635D8AA3A93E7B3EBBD55769886BC651D06B0CC53B0F63BCE3C3E27D2604B", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("006B17D1F2E12C4247F8BCE6E563A440F277037D812DEB33A0F4A13945D898C296", NumberStyles.HexNumber), BigInteger.Parse("004FE342E2FE1A7F9B8EE7EB4A7C0F9E162BCE33576B315ECECBB6406837BF51F5", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00FFFFFFFF00000000FFFFFFFFFFFFFFFFBCE6FAADA7179E84F3B9CAC2FC632551", NumberStyles.HexNumber);
						H = 1;

						Length = 256;
					}
					break;
				case Names.secp256k1:
					{
						Name = name;

						P = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFC2F", NumberStyles.HexNumber);

						A = 0;
						B = 7;

						G = new Point(BigInteger.Parse("79BE667EF9DCBBAC55A06295CE870B07029BFCDB2DCE28D959F2815B16F81798", NumberStyles.HexNumber), BigInteger.Parse("483ADA7726A3C4655DA4FBFC0E1108A8FD17B448A68554199C47D08FFB10D4B8", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEBAAEDCE6AF48A03BBFD25E8CD0364141", NumberStyles.HexNumber);
						H = 1;

						Length = 256;
					}
					break;
				default:
					throw new UnknownCurveException($"Unknown curve ({name.ToString()}) has been requested.");
			}
		}

		/// <summary>
		/// Creates an elliptic-curve instance with custom parameters.
		/// </summary>
		/// <param name="p"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="g"></param>
		/// <param name="n"></param>
		/// <param name="h"></param>
		/// <param name="length"></param>
		public Curve(BigInteger p, BigInteger a, BigInteger b, Point g, BigInteger n, short h, uint length)
		{
			Name = null;

			P = p;

			A = a;
			B = b;

			G = g;

			N = n;
			H = h;

			Length = length;
		}

		/// <summary>
		/// Checks whether a point is on the elliptic-curve.
		/// </summary>
		/// <param name="point">Point to check.</param>
		/// <returns>True if point is on the elliptic-curve.</returns>
		public bool IsOnCurve(Point point) => Point.IsInfinityPoint(point) ? true : ((BigInteger.Pow(point.Y, 2) - BigInteger.Pow(point.X, 3) - A * point.X - B) % P) == 0;

		/// <summary>
		/// Checks whether a point is valid.
		/// </summary>
		/// <param name="point">Point to check.</param>
		/// <param name="exception">Exception to be thrown if the point is not valid.</param>
		public void CheckPoint(Point point, Exception exception)
		{
			if (!IsOnCurve(point))
				throw exception;
		}
	}
}