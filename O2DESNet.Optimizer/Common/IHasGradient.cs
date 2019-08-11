using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IHasGradient : ISingleObjectiveEvaluator
    {
        IList<double> GetGradient(IList<double> decisions);
    }
}
