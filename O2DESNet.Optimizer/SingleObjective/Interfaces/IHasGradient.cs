using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface IHasGradient : IEvaluator
    {
        Vector GetGradient(Vector decisions);
    }
}
