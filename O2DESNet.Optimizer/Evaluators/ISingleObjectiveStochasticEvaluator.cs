using MathNet.Numerics.Distributions;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Single-objective stochastic evaluator
    /// </summary>
    public interface ISingleObjectiveStochasticEvaluator : ISingleObjectiveEvaluator, IDistribution
    {
    }

    public interface ISingleObjectiveStochasticEvaluator<T> : ISingleObjectiveEvaluator<T>, IDistribution
    {
    }
}
