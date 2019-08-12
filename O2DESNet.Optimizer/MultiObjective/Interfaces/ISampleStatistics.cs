using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Text;

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
