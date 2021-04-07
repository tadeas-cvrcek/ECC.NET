using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ECC.NET.Tests.Protocols
{
	public abstract class ProtocolBase : ICurveSpecific
	{
		protected Curve curve;
		public abstract Curve Curve { get; }

		[Fact]
		public void ECDH()
		{
			Cryptography.KeyPair aliceKeyPair = Cryptography.GetKeyPair(Curve);
			Cryptography.KeyPair bobKeyPair = Cryptography.GetKeyPair(Curve);

			Point aliceSharedSecret = Cryptography.GetSharedSecret(aliceKeyPair.PrivateKey, bobKeyPair.PublicKey);
			Point bobSharedSecret = Cryptography.GetSharedSecret(bobKeyPair.PrivateKey, aliceKeyPair.PublicKey);

			Assert.True(aliceSharedSecret.X == bobSharedSecret.X && aliceSharedSecret.Y == bobSharedSecret.Y);
		}
	}
}
