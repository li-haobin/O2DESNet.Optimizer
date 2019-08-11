using System.Collections.Generic;

namespace O2DESNet.Optimizer.MultiObjective
{
    /// <summary>
    /// Multi-objective deterministic evaluator
    /// </summary>
    public interface IEvaluator : IEvaluator<IList<double>>, IQuantitativeDomain
    {
    }

    public interface IEvaluator<T> : Optimizer.IEvaluator
    {
        int NumberObjectives { get; }
        IList<double> Evaluate(T design);
    }
}
