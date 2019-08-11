using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Single-objective stochastic evaluator
    /// </summary>
    public interface ISingleObjectiveStochasticEvaluator : ISingleObjectiveEvaluator, IDistribution
    {
    }

    public interface ISingleObjectiveStochasticEvaluator<T> : ISingleObjectiveEvaluator<T>, IDistribution
    {
    }
}
