using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    /// <summary>
    /// Multi-objective stochastic evaluator
    /// </summary>
    public interface IMultiObjectiveStochasticEvaluator : IMultiObjectiveEvaluator, IDistribution
    {
    }

    public interface IMultiObjectiveStochasticEvaluator<T> : IMultiObjectiveEvaluator<T>, IDistribution
    {
    }
}
