using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Single-objective deterministic evaluator
    /// </summary>
    public interface ISingleObjectiveEvaluator : ISingleObjectiveEvaluator<IList<double>>, IQuantitativeDomain
    {
    }

    public interface ISingleObjectiveEvaluator<T> : IEvaluator
    {
        double Evaluate(T decisions);
    }
}
