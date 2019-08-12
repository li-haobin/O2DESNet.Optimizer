using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer
{
    public interface IKnownOptimum
    {
        Vector[] Optimum { get; }
    }
}
