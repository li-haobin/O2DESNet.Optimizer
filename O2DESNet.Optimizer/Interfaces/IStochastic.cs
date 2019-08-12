using System;

namespace O2DESNet.Optimizer
{
    public interface IStochastic
    {
        Random RandomStream { get; }
    }
}
