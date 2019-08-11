using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    public interface IKnownOptimum
    {
        IReadOnlyList<IReadOnlyList<double>> Optimum { get; }
    }
}
