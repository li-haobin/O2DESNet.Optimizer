using O2DESNet.Optimizer.MultiObjective;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IParetoSelector<T>
    {
        IEvaluator<T> Evaluator { get; }
        ICollection<T> Select(ICollection<T> candidates);
    }
}
