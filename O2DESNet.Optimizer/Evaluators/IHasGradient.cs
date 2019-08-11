using System.Collections.Generic;

namespace O2DESNet.Optimizer
{
    public interface IHasGradient : ISingleObjectiveEvaluator
    {
        IList<double> GetGradient(IList<double> decisions);
    }
}
