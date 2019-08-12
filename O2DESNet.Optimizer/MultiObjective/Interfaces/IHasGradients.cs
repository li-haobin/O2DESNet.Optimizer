using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.MultiObjective
{
    public interface IHasGradients : IEvaluator
    {
        Vector[] GetGradients(Vector decisions);
    }
}
