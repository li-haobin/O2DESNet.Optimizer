﻿using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface IKnownPerformance<T> : IStochasticEvaluator<T>
    {
        double PopulationMean(T design);
        double PopulationStandardDeviation(T design);
    }

    public interface IKnownPerformance : IKnownPerformance<Vector>
    {
    }
}
