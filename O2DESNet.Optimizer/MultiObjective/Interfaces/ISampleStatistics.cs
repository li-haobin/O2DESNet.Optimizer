using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.MultiObjective
{
    public interface ISampleStatistics<T> : IStochasticEvaluator<T>, Optimizer.ISampleStatistics
    {
        IReadOnlyDictionary<T, IReadOnlyList<Vector>> Observations { get; }
        IReadOnlyDictionary<T, Vector> SampleMeans { get; }
        IReadOnlyDictionary<T, Vector> SampleStandardDeviations { get; }
    }

    public interface ISampleStatistics : IKnownPerformance<Vector>
    {
    }
}
