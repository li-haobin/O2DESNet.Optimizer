using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.MultiObjective
{
    public interface IHasGradients : IEvaluator
    {
        Matrix<double> GetGradients(IList<double> decisions);
    }
}
