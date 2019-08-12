using MathNet.Numerics.LinearAlgebra.Double;

namespace O2DESNet.Optimizer.MultiObjective
{
    public interface IHasGradients : IEvaluator
    {
        Vector[] GetGradients(Vector decisions);
    }
}
