﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC.NET.Tests.Protocols
{
	public class brainpoolp512r1 : ProtocolBase
	{
		public override Curve Curve
		{
			get
			{
				if (curve is null)
					curve = new Curve(Curve.CurveName.brainpoolp512r1);

				return curve;
			}
		}
	}
}