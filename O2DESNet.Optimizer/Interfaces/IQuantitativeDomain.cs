using MathNet.Numerics.LinearAlgebra.Double;

namespace O2DESNet.Optimizer
{
    public interface IQuantitativeDomain
    {
        Vector LowerBounds { get; }
        Vector UpperBounds { get; }

        int NumberDecisions { get; }
    }
}
