﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC.NET.Tests.Protocols
{
	public class brainpoolp256r1 : ProtocolBase
	{
		public override Curve Curve
		{
			get
			{
				if (curve is null)
					curve = new Curve(Curve.CurveName.brainpoolp256r1);

				return curve;
			}
		}
	}
}
