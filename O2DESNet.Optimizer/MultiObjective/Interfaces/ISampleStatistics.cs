using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer.MultiObjective
{
    public interface ISampleStatistics<T> : IStochasticEvaluator<T>
    {
        IReadOnlyDictionary<T, IReadOnlyList<Vector>> Observations { get; }
        Vector SampleMeans(T design);
        Vector SampleDeviations(T design);
    }

    public interface ISampleStatistics : IKnownPerformance<Vector>
    {
    }
}
