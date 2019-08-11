using System.Collections.Generic;

namespace O2DESNet.Optimizer.SingleObjective
{
    /// <summary>
    /// Single-objective deterministic evaluator
    /// </summary>
    public interface IEvaluator : IEvaluator<IList<double>>, IQuantitativeDomain
    {
    }

    public interface IEvaluator<T> : Optimizer.IEvaluator
    {
        double Evaluate(T design);
    }
}
