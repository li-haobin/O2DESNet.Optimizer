using MathNet.Numerics.LinearAlgebra.Double;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface IHasGradient : IEvaluator
    {
        Vector GetGradient(Vector decisions);
    }
}
