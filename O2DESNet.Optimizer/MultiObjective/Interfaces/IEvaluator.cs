using MathNet.Numerics.LinearAlgebra.Double;

namespace O2DESNet.Optimizer.MultiObjective
{
    /// <summary>
    /// Multi-objective deterministic evaluator
    /// </summary>
    public interface IEvaluator : IEvaluator<Vector>, IQuantitativeDomain
    {
        int NumberDecisions { get; }
    }

    public interface IEvaluator<T> : INamed
    {
        int NumberObjectives { get; }
        Vector Evaluate(T design);
    }
}
