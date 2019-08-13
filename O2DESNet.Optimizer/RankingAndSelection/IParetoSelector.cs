using O2DESNet.Optimizer.MultiObjective;
using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    public interface IParetoSelector<T>
    {
        IStochasticEvaluator<T> Evaluator { get; }
        ICollection<T> Select(ICollection<T> candidates);
    }
}
