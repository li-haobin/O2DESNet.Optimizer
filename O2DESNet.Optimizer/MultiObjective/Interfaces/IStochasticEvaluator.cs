using MathNet.Numerics.Distributions;

namespace O2DESNet.Optimizer.MultiObjective
{
    /// <summary>
    /// Multi-objective stochastic evaluator
    /// </summary>
    public interface IStochasticEvaluator : IEvaluator, IDistribution
    {
    }

    public interface IStochasticEvaluator<T> : IEvaluator<T>, IDistribution
    {
    }
}
