using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    public interface IHasMultiGradient : IMultiObjectiveEvaluator
    {
        Matrix<double> GetGradient(IList<double> decisions);
    }
}
