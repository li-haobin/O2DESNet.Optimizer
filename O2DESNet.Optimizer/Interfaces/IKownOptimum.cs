using MathNet.Numerics.LinearAlgebra.Double;

namespace O2DESNet.Optimizer
{
    public interface IKnownOptimum
    {
        Vector[] Optimum { get; }
    }
}
