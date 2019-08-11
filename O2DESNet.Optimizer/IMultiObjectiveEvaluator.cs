using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Multi-objective deterministic evaluator
    /// </summary>
    public interface IMultiObjectiveEvaluator : IEvaluator, IQuantitativeDomain
    {
        IList<double> Evaluate(IList<double> decisions);
    }

    public interface IMultiObjectiveEvaluator<T> : IEvaluator
    {
        IList<double> Evaluate(T design);
    }
}
