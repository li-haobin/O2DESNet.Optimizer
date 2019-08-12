﻿using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    public interface IQuantitativeDomain
    {
        Vector LowerBounds { get; }
        Vector UpperBounds { get; }
    }
}
