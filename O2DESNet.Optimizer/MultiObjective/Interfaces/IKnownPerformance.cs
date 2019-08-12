using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Text;

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
