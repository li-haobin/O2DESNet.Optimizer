using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    public interface IQuantitativeDomain
    {
        IReadOnlyList<double> LowerBounds { get; }
        IReadOnlyList<double> UpperBounds { get; }
    }
}
