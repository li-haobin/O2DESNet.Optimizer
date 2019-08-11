using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Multi-objective deterministic evaluator
    /// </summary>
    public interface IMultiObjectiveEvaluator : IMultiObjectiveEvaluator<IList<double>>, IQuantitativeDomain
    {
    }

    public interface IMultiObjectiveEvaluator<T> : IEvaluator
    {
        int NumberObjectives { get; }
        IList<double> Evaluate(T decisions);
    }
}
