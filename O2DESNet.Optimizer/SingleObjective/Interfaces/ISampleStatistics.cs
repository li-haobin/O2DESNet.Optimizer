using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface ISampleStatistics<T> : IStochasticEvaluator<T>
    {
        IReadOnlyDictionary<T, IReadOnlyList<double>> Observations { get; }
        double SampleMean(T design);
        double SampleDeviation(T design);
    }

    public interface ISampleStatistics : IKnownPerformance<IList<double>>
    {
    }
}
