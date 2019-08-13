using O2DESNet.Optimizer.SingleObjective;
using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    public interface IBestSelector<T>
    {
        IStochasticEvaluator<T> Evaluator { get; }
        T Select(ICollection<T> candidates);
    }
}
