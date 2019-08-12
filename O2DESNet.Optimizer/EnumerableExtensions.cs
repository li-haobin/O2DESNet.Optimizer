using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer
{
    public static class EnumerableExtensions
    {
        public static Vector ToDenseVector(this IEnumerable<double> enumerable)
        {
            return (DenseVector)enumerable.ToArray();
        }
    }
}
