﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC.NET.Tests.PointOperations
{
	public class brainpoolp192r1 : PointOperationsBase
	{
		public override Curve Curve
		{
			get
			{
				if (curve is null)
					curve = new Curve(Curve.CurveName.brainpoolp192r1);

				return curve;
			}
		}
	}
}