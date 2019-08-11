using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Single-objective deterministic evaluator
    /// </summary>
    public interface ISingleObjectiveEvaluator : IEvaluator, IQuantitativeDomain
    {
        double Evaluate(IList<double> decisions);
    }

    public interface ISingleObjectiveEvaluator<T> : IEvaluator
    {
        double Evaluate(T design);
    }
}
