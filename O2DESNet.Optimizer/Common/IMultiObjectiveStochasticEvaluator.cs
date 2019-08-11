using MathNet.Numerics.Distributions;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Multi-objective stochastic evaluator
    /// </summary>
    public interface IMultiObjectiveStochasticEvaluator : IMultiObjectiveEvaluator, IDistribution
    {
    }

    public interface IMultiObjectiveStochasticEvaluator<T> : IMultiObjectiveEvaluator<T>, IDistribution
    {
    }
}
