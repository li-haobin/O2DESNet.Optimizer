using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IBestSelector<T>
    {
        ISingleObjectiveStochasticEvaluator<T> Evaluator { get; }
        T Select(IList<T> candidates);
    }
}
