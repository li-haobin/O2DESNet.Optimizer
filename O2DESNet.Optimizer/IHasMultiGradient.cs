using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IHasMultiGradient : IMultiObjectiveEvaluator
    {
        Matrix<double> GetGradient(IList<double> decisions);
    }
}
