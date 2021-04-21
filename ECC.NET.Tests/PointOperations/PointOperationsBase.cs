using ECC.NET;
using ECC.NET.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECC.NET.Tests.PointOperations
{
	public abstract class PointOperationsBase : ICurveSpecific
	{
		protected Curve curve;
		public abstract Curve Curve { get; }

		[Fact]
		public void IsOnCurve() => Assert.True(Curve.IsOnCurve(Curve.G));

		[Fact]
		public void Add() => Assert.True(Curve.IsOnCurve(Point.Add(Curve.G, Curve.G)));

		[Fact]
		public void Subtract() => Assert.True(Curve.IsOnCurve(Point.Subtract(Point.Multiply(Random(), Curve.G), Curve.G)));

		[Fact]
		public void Multiply() => Assert.True(Curve.IsOnCurve(Point.Multiply(Random(), Curve.G)));

		[Fact]
		public void Negate() => Assert.True(Curve.IsOnCurve(Point.Negate(Curve.G)));

		[Fact]
		public void Double() => Assert.True(Curve.IsOnCurve(Point.Double(Curve.G)));

		public BigInteger Random()
		{
			byte[] byteArray = new byte[curve.Length / 8];
			byteArray.Randomize();

			return new BigInteger(byteArray);
		}
	}
}
