using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer.MultiObjective
{
    public interface IKnownPerformance<T> : IStochasticEvaluator<T>
    {
        Vector PopulationMeans(T design);
        Vector PopulationStandardDeviations(T design);
    }

    public interface IKnownPerformance : IKnownPerformance<Vector>
    {
    }
}
