using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface ISampleStatistics<T> : IStochasticEvaluator<T>, Optimizer.ISampleStatistics
    {
        IReadOnlyDictionary<T, IReadOnlyList<double>> Observations { get; }
        IReadOnlyDictionary<T, double> SampleMeans { get; }
        IReadOnlyDictionary<T, double> SampleStandardDeviations { get; }
    }

    public interface ISampleStatistics : ISampleStatistics<Vector>
    {
    }
}
