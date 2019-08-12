using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.SingleObjective
{
    /// <summary>
    /// Single-objective deterministic evaluator
    /// </summary>
    public interface IEvaluator : IEvaluator<Vector>, IQuantitativeDomain
    {
    }

    public interface IEvaluator<T> : Optimizer.IEvaluator
    {
        double Evaluate(T design);
    }
}
