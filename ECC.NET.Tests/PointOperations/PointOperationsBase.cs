using System;
using System.Collections.Generic;
using System.Linq;
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
		public void Multiply() => Assert.True(Curve.IsOnCurve(Point.Multiply(2, Curve.G)));

		[Fact]
		public void Negate() => Assert.True(Curve.IsOnCurve(Point.Negate(Curve.G)));

		[Fact]
		public void Double() => Assert.True(Curve.IsOnCurve(Point.Double(Curve.G)));
	}
}
