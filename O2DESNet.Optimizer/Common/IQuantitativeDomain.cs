﻿using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IQuantitativeDomain
    {
        IReadOnlyList<double> LowerBounds { get; }
        IReadOnlyList<double> UpperBounds { get; }
    }
}