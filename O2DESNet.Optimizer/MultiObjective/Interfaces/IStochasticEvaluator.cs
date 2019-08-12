namespace O2DESNet.Optimizer.MultiObjective
{
    /// <summary>
    /// Multi-objective stochastic evaluator
    /// </summary>
    public interface IStochasticEvaluator : IEvaluator, IStochastic
    {
    }

    public interface IStochasticEvaluator<T> : IEvaluator<T>, IStochastic
    {
    }
}
