using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IQuantitativeDomain
    {
        double GlobalLowerBound { get; }
        double GlobalUpperBound { get; }
        IList<double> LowerBounds { get; }
        IList<double> UpperBounds { get; }
    }
}
