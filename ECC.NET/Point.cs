using ECC.NET.Exceptions;
using System;
using System.Numerics;

namespace ECC.NET
{
	/// <summary>
	/// ECC.NET elliptic-curve point class.
	/// </summary>
	public class Point
	{
		public static Point InfinityPoint => null;
		public static bool IsInfinityPoint(Point point) => point == InfinityPoint;

		public BigInteger X { get; set; }
		public BigInteger Y { get; set; }
		public Curve Curve { get; set; }

		/// <summary>
		/// Creates an elliptic-curve point instance.
		/// </summary>
		/// <param name="x">X coordinate.</param>
		/// <param name="y">Y coordinate.</param>
		/// <param name="curve">Appropriate elliptic-curve instance.</param>
		public Point(BigInteger x, BigInteger y, Curve curve)
		{
			X = x;
			Y = y;

			Curve = curve;
		}

		/// <summary>
		/// Checks whether the point is valid.
		/// </summary>
		/// <param name="exception">Exception to be thrown if the point is not valid.</param>
		public void CheckPoint(Exception exception) => Curve.CheckPoint(this, exception);

		/// <summary>
		/// Multiplies given point by given scalar.
		/// </summary>
		/// <param name="scalar">Scalar to multiply by.</param>
		/// <param name="point">Point to be multiplied.</param>
		/// <returns></returns>
		public static Point Multiply(BigInteger scalar, Point point)
		{
			if (Point.IsInfinityPoint(point) || scalar % point.Curve.N == 0)
				return Point.InfinityPoint;

			point.Curve.CheckPoint(point, new InvalidPointException("Point is not on specified curve."));

			if (scalar < 0)
				return Multiply(-scalar, Negate(point));

			Point result = Point.InfinityPoint;
			Point addend = point;

			while (scalar != 0)
			{
				if ((scalar & 1) == 1)
					result = Add(result, addend);

				addend = Add(addend, addend);

				scalar >>= 1;
			}

			point.Curve.CheckPoint(result, new InvalidPointException("Point is not on specified curve."));

			return result;
		}

		/// <summary>
		/// Adds two points on the same curve.
		/// </summary>
		/// <param name="first"></param>
		/// <param name="second"></param>
		/// <returns></returns>
		public static Point Add(Point first, Point second)
		{
			if (Point.IsInfinityPoint(first))
				return second;

			if (Point.IsInfinityPoint(second))
				return first;

			Curve commonCurve;

			if (first.Curve == second.Curve)
				commonCurve = first.Curve;
			else
				throw new CurvesMismatchException("Used curves does not match.");

			commonCurve.CheckPoint(first, new InvalidPointException("Point is not on specified curve."));
			commonCurve.CheckPoint(second, new InvalidPointException("Point is not on specified curve."));

			BigInteger temporary;

			if (first.X == second.X)
			{
				if (first.Y != second.Y)
					return Point.InfinityPoint;

				temporary = (3 * BigInteger.Pow(first.X, 2) + commonCurve.A) * Numerics.ModularInverse(2 * first.Y, commonCurve.P);
			}
			else
				temporary = (first.Y - second.Y) * Numerics.ModularInverse(first.X - second.X, commonCurve.P);

			BigInteger newX = BigInteger.Pow(temporary, 2) - first.X - second.X;
			BigInteger newY = first.Y + temporary * (newX - first.X);
			Point result = new Point(Numerics.Modulus(newX, commonCurve.P), Numerics.Modulus(-newY, commonCurve.P), commonCurve);

			return result;
		}

		/// <summary>
		/// Adds multiple points on the same curve.
		/// </summary>
		/// <param name="points">Points to add.</param>
		/// <returns></returns>
		public static Point Add(params Point[] points)
		{
			if (points.Length <= 2)
				throw new ArgumentException("Minimum number of points is 2.");

			Point result = Point.InfinityPoint;
			for (int i = 1; i < points.Length; i++)
				result = Point.Add(points[i - 1], points[i]);

			return result;
		}
		
		/// <summary>
		/// Doubles a point.
		/// </summary>
		/// <param name="point">Point to double.</param>
		/// <returns></returns>
		public static Point Double(Point point)
		{
			return Point.Add(point, point);
		}

		/// <summary>
		/// Negates a point.
		/// </summary>
		/// <param name="point">Point to negate.</param>
		/// <returns></returns>
		public static Point Negate(Point point)
		{
			point.CheckPoint(new InvalidPointException("Point is not on specified curve."));

			if (Point.IsInfinityPoint(point))
				return point;

			Point result = new Point(point.X, Numerics.Modulus(-point.Y, point.Curve.P), point.Curve);

			result.CheckPoint(new InvalidPointException("Point is not on specified curve."));

			return result;
		}

		public override string ToString()
		{
			return string.Concat(X, Y);
		}

		/// <summary>
		/// Return formatted string representing a point.
		/// </summary>
		/// <param name="format">Target format, where X represents X coordinate and Y represents Y coordinate.</param>
		/// <returns></returns>
		public string ToString(string format)
		{
			return format.Replace("X", X.ToString()).Replace("Y", Y.ToString());
		}
	}
}
