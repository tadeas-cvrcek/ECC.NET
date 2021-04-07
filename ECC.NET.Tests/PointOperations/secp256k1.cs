using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC.NET.Tests.PointOperations
{
	public class secp256k1 : PointOperationsBase
	{
		public override Curve Curve
		{
			get
			{
				if (curve is null)
					curve = new Curve(Curve.CurveName.secp256k1);

				return curve;
			}
		}
	}
}
