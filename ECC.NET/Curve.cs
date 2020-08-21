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
		public enum CurveName
		{
			brainpoolp160r1,
			brainpoolp192r1,
			brainpoolp224r1,
			brainpoolp256r1,
			brainpoolp320r1,
			brainpoolp384r1,
			brainpoolp512r1,
			nistp192,
			nistp256,
			nistp384,
			nistp521,
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

		public CurveName? Name { get; private set; }
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
		public Curve(CurveName name)
		{
			switch (name)
			{
				case CurveName.brainpoolp160r1:
					{
						Name = name;

						P = BigInteger.Parse("00E95E4A5F737059DC60DFC7AD95B3D8139515620F", NumberStyles.HexNumber);

						A = BigInteger.Parse("00340E7BE2A280EB74E2BE61BADA745D97E8F7C300", NumberStyles.HexNumber);
						B = BigInteger.Parse("001E589A8595423412134FAA2DBDEC95C8D8675E58", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00BED5AF16EA3F6A4F62938C4631EB5AF7BDBCDBC3", NumberStyles.HexNumber), BigInteger.Parse("001667CB477A1A8EC338F94741669C976316DA6321", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00E95E4A5F737059DC60DF5991D45029409E60FC09", NumberStyles.HexNumber);
						H = 1;

						Length = 160;
					}
					break;
				case CurveName.brainpoolp192r1:
					{
						Name = name;

						P = BigInteger.Parse("00C302F41D932A36CDA7A3463093D18DB78FCE476DE1A86297", NumberStyles.HexNumber);

						A = BigInteger.Parse("006A91174076B1E0E19C39C031FE8685C1CAE040E5C69A28EF", NumberStyles.HexNumber);
						B = BigInteger.Parse("00469A28EF7C28CCA3DC721D044F4496BCCA7EF4146FBF25C9", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00C0A0647EAAB6A48753B033C56CB0F0900A2F5C4853375FD6", NumberStyles.HexNumber), BigInteger.Parse("0014B690866ABD5BB88B5F4828C1490002E6773FA2FA299B8F", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00C302F41D932A36CDA7A3462F9E9E916B5BE8F1029AC4ACC1", NumberStyles.HexNumber);
						H = 1;

						Length = 192;
					}
					break;
				case CurveName.brainpoolp224r1:
					{
						Name = name;

						P = BigInteger.Parse("00D7C134AA264366862A18302575D1D787B09F075797DA89F57EC8C0FF", NumberStyles.HexNumber);

						A = BigInteger.Parse("0068A5E62CA9CE6C1C299803A6C1530B514E182AD8B0042A59CAD29F43", NumberStyles.HexNumber);
						B = BigInteger.Parse("002580F63CCFE44138870713B1A92369E33E2135D266DBB372386C400B", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("000D9029AD2C7E5CF4340823B2A87DC68C9E4CE3174C1E6EFDEE12C07D", NumberStyles.HexNumber), BigInteger.Parse("0058AA56F772C0726F24C6B89E4ECDAC24354B9E99CAA3F6D3761402CD", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00D7C134AA264366862A18302575D0FB98D116BC4B6DDEBCA3A5A7939F", NumberStyles.HexNumber);
						H = 1;

						Length = 224;
					}
					break;
				case CurveName.brainpoolp256r1:
					{
						Name = name;

						P = BigInteger.Parse("00A9FB57DBA1EEA9BC3E660A909D838D726E3BF623D52620282013481D1F6E5377", NumberStyles.HexNumber);

						A = BigInteger.Parse("007D5A0975FC2C3057EEF67530417AFFE7FB8055C126DC5C6CE94A4B44F330B5D9", NumberStyles.HexNumber);
						B = BigInteger.Parse("0026DC5C6CE94A4B44F330B5D9BBD77CBF958416295CF7E1CE6BCCDC18FF8C07B6", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("008BD2AEB9CB7E57CB2C4B482FFC81B7AFB9DE27E1E3BD23C23A4453BD9ACE3262", NumberStyles.HexNumber), BigInteger.Parse("00547EF835C3DAC4FD97F8461A14611DC9C27745132DED8E545C1D54C72F046997", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00A9FB57DBA1EEA9BC3E660A909D838D718C397AA3B561A6F7901E0E82974856A7", NumberStyles.HexNumber);
						H = 1;

						Length = 256;
					}
					break;
				case CurveName.brainpoolp320r1:
					{
						Name = name;

						P = BigInteger.Parse("00D35E472036BC4FB7E13C785ED201E065F98FCFA6F6F40DEF4F92B9EC7893EC28FCD412B1F1B32E27", NumberStyles.HexNumber);

						A = BigInteger.Parse("003EE30B568FBAB0F883CCEBD46D3F3BB8A2A73513F5EB79DA66190EB085FFA9F492F375A97D860EB4", NumberStyles.HexNumber);
						B = BigInteger.Parse("00520883949DFDBC42D3AD198640688A6FE13F41349554B49ACC31DCCD884539816F5EB4AC8FB1F1A6", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("0043BD7E9AFB53D8B85289BCC48EE5BFE6F20137D10A087EB6E7871E2A10A599C710AF8D0D39E20611", NumberStyles.HexNumber), BigInteger.Parse("0014FDD05545EC1CC8AB4093247F77275E0743FFED117182EAA9C77877AAAC6AC7D35245D1692E8EE1", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00D35E472036BC4FB7E13C785ED201E065F98FCFA5B68F12A32D482EC7EE8658E98691555B44C59311", NumberStyles.HexNumber);
						H = 1;

						Length = 320;
					}
					break;
				case CurveName.brainpoolp384r1:
					{
						Name = name;

						P = BigInteger.Parse("008CB91E82A3386D280F5D6F7E50E641DF152F7109ED5456B412B1DA197FB71123ACD3A729901D1A71874700133107EC53", NumberStyles.HexNumber);

						A = BigInteger.Parse("007BC382C63D8C150C3C72080ACE05AFA0C2BEA28E4FB22787139165EFBA91F90F8AA5814A503AD4EB04A8C7DD22CE2826", NumberStyles.HexNumber);
						B = BigInteger.Parse("0004A8C7DD22CE28268B39B55416F0447C2FB77DE107DCD2A62E880EA53EEB62D57CB4390295DBC9943AB78696FA504C11", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("001D1C64F068CF45FFA2A63A81B7C13F6B8847A3E77EF14FE3DB7FCAFE0CBD10E8E826E03436D646AAEF87B2E247D4AF1E", NumberStyles.HexNumber), BigInteger.Parse("008ABE1D7520F9C2A45CB1EB8E95CFD55262B70B29FEEC5864E19C054FF99129280E4646217791811142820341263C5315", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("008CB91E82A3386D280F5D6F7E50E641DF152F7109ED5456B31F166E6CAC0425A7CF3AB6AF6B7FC3103B883202E9046565", NumberStyles.HexNumber);
						H = 1;

						Length = 384;
					}
					break;
				case CurveName.brainpoolp512r1:
					{
						Name = name;

						P = BigInteger.Parse("00AADD9DB8DBE9C48B3FD4E6AE33C9FC07CB308DB3B3C9D20ED6639CCA703308717D4D9B009BC66842AECDA12AE6A380E62881FF2F2D82C68528AA6056583A48F3", NumberStyles.HexNumber);

						A = BigInteger.Parse("007830A3318B603B89E2327145AC234CC594CBDD8D3DF91610A83441CAEA9863BC2DED5D5AA8253AA10A2EF1C98B9AC8B57F1117A72BF2C7B9E7C1AC4D77FC94CA", NumberStyles.HexNumber);
						B = BigInteger.Parse("003DF91610A83441CAEA9863BC2DED5D5AA8253AA10A2EF1C98B9AC8B57F1117A72BF2C7B9E7C1AC4D77FC94CADC083E67984050B75EBAE5DD2809BD638016F723", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("0081AEE4BDD82ED9645A21322E9C4C6A9385ED9F70B5D916C1B43B62EEF4D0098EFF3B1F78E2D0D48D50D1687B93B97D5F7C6D5047406A5E688B352209BCB9F822", NumberStyles.HexNumber), BigInteger.Parse("007DDE385D566332ECC0EABFA9CF7822FDF209F70024A57B1AA000C55B881F8111B2DCDE494A5F485E5BCA4BD88A2763AED1CA2B2FA8F0540678CD1E0F3AD80892", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("00AADD9DB8DBE9C48B3FD4E6AE33C9FC07CB308DB3B3C9D20ED6639CCA70330870553E5C414CA92619418661197FAC10471DB1D381085DDADDB58796829CA90069", NumberStyles.HexNumber);
						H = 1;

						Length = 512;
					}
					break;
				case CurveName.nistp192:
					{
						Name = name;

						P = BigInteger.Parse("000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFFFFFFFFFF", NumberStyles.HexNumber);

						A = BigInteger.Parse("D", NumberStyles.HexNumber);
						B = BigInteger.Parse("0064210519E59C80E70FA7E9AB72243049FEB8DEECC146B9B1", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00188DA80EB03090F67CBF20EB43A18800F4FF0AFD82FF1012", NumberStyles.HexNumber), BigInteger.Parse("0007192B95FFC8DA78631011ED6B24CDD573F977A11E794811", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("000FFFFFFFFFFFFFFFFFFFFFFFF99DEF836146BC9B1B4D22831", NumberStyles.HexNumber);
						H = 1;

						Length = 192;
					}
					break;
				case CurveName.nistp256:
					{
						Name = name;

						P = BigInteger.Parse("000FFFFFFFF00000001000000000000000000000000FFFFFFFFFFFFFFFFFFFFFFFF", NumberStyles.HexNumber);

						A = BigInteger.Parse("D", NumberStyles.HexNumber);
						B = BigInteger.Parse("005AC635D8AA3A93E7B3EBBD55769886BC651D06B0CC53B0F63BCE3C3E27D2604B", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("006B17D1F2E12C4247F8BCE6E563A440F277037D812DEB33A0F4A13945D898C296", NumberStyles.HexNumber), BigInteger.Parse("004FE342E2FE1A7F9B8EE7EB4A7C0F9E162BCE33576B315ECECBB6406837BF51F5", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("000FFFFFFFF00000000FFFFFFFFFFFFFFFFBCE6FAADA7179E84F3B9CAC2FC632551", NumberStyles.HexNumber);
						H = 1;

						Length = 256;
					}
					break;
				case CurveName.nistp384:
					{
						Name = name;

						P = BigInteger.Parse("000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFEFFFFFFFF0000000000000000FFFFFFFF", NumberStyles.HexNumber);

						A = BigInteger.Parse("D", NumberStyles.HexNumber);
						B = BigInteger.Parse("00B3312FA7E23EE7E4988E056BE3F82D19181D9C6EFE8141120314088F5013875AC656398D8A2ED19D2A85C8EDD3EC2AEF", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00AA87CA22BE8B05378EB1C71EF320AD746E1D3B628BA79B9859F741E082542A385502F25DBF55296C3A545E3872760AB7", NumberStyles.HexNumber), BigInteger.Parse("003617DE4A96262C6F5D9E98BF9292DC29F8F41DBD289A147CE9DA3113B5F0B8C00A60B1CE1D7E819D7A431D7C90EA0E5F", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("000FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC7634D81F4372DDF581A0DB248B0A77AECEC196ACCC52973", NumberStyles.HexNumber);
						H = 1;

						Length = 384;
					}
					break;
				case CurveName.nistp521:
					{
						Name = name;

						P = BigInteger.Parse("001FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF", NumberStyles.HexNumber);

						A = BigInteger.Parse("D", NumberStyles.HexNumber);
						B = BigInteger.Parse("00051953EB9618E1C9A1F929A21A0B68540EEA2DA725B99B315F3B8B489918EF109E156193951EC7E937B1652C0BD3BB1BF073573DF883D2C34F1EF451FD46B503F00", NumberStyles.HexNumber);

						G = new Point(BigInteger.Parse("00C6858E06B70404E9CD9E3ECB662395B4429C648139053FB521F828AF606B4D3DBAA14B5E77EFE75928FE1DC127A2FFA8DE3348B3C1856A429BF97E7E31C2E5BD66", NumberStyles.HexNumber), BigInteger.Parse("0011839296A789A3BC0045C8A5FB42C7D1BD998F54449579B446817AFBD17273E662C97EE72995EF42640C550B9013FAD0761353C7086A272C24088BE94769FD16650", NumberStyles.HexNumber), this);

						N = BigInteger.Parse("001FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFA51868783BF2F966B7FCC0148F709A5D03BB5C9B8899C47AEBB6FB71E91386409", NumberStyles.HexNumber);
						H = 1;

						Length = 521;
					}
					break;
				case CurveName.secp160r1:
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
				case CurveName.secp160r2:
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
				case CurveName.secp160k1:
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
				case CurveName.secp192r1:
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
				case CurveName.secp192k1:
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
				case CurveName.secp224r1:
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
				case CurveName.secp224k1:
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
				case CurveName.secp256r1:
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
				case CurveName.secp256k1:
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