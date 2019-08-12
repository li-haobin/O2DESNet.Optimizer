using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;
using System.Linq;

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
