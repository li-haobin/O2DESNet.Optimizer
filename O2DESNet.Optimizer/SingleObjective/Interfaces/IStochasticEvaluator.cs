namespace O2DESNet.Optimizer.SingleObjective
{
    /// <summary>
    /// Single-objective stochastic evaluator
    /// </summary>
    public interface IStochasticEvaluator : IEvaluator, IStochastic
    {
    }

    public interface IStochasticEvaluator<T> : IEvaluator<T>, IStochastic
    {
    }
}
