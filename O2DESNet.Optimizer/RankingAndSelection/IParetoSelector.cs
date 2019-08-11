using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IParetoSelector<T>
    {
        IMultiObjectiveStochasticEvaluator<T> Evaluator { get; }
        T Select(IList<T> candidates);
    }
}
