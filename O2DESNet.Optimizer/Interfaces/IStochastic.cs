using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IStochastic
    {
        Random RandomStream { get; }
    }
}
