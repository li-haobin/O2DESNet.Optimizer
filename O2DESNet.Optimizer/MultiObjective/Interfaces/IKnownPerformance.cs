using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.MultiObjective
{
    public interface IKnownPerformance<T> : IStochasticEvaluator<T>
    {
        IReadOnlyDictionary<T, Vector> TrueMeans { get; }
        IReadOnlyDictionary<T, Vector> TrueStandardDeviations { get; }
    }

    public interface IKnownPerformance : IKnownPerformance<Vector>
    {
    }
}
