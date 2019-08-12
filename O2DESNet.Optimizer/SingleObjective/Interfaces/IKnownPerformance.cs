using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface IKnownPerformance<T> : IStochasticEvaluator<T>
    {
        IReadOnlyDictionary<T, double> TrueMeans { get; }
        IReadOnlyDictionary<T, double> TrueStandardDeviations { get; }
    }

    public interface IKnownPerformance : IKnownPerformance<Vector>
    {
    }
}
