using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IKnownOptimum
    {
        IReadOnlyList<IReadOnlyList<double>> KnownOptimum { get; }
    }
}
