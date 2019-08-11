using System.Collections.Generic;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface IHasGradient : IEvaluator
    {
        IList<double> GetGradient(IList<double> decisions);
    }
}
