using MathNet.Numerics.LinearAlgebra.Double;

namespace O2DESNet.Optimizer.SingleObjective
{
    /// <summary>
    /// Single-objective deterministic evaluator
    /// </summary>
    public interface IEvaluator : IEvaluator<Vector>, IQuantitativeDomain
    {
        int NumberDecisions { get; }
    }

    public interface IEvaluator<T> : INamed
    {
        double Evaluate(T design);
    }
}
