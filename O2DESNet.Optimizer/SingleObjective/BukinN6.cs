using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective
{
    /// <summary>
    /// http://www.sfu.ca/~ssurjano/bukin6.html
    /// </summary>
    public class BukinN6 : IEvaluator
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }
        
        public BukinN6()
        {
            NumberDecisions = 2;
            Name = string.Format("BukinN6/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-5d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(5d, NumberDecisions).ToDenseVector();
        }

        public double Evaluate(Vector x)
        {
            return Math.Sqrt(Math.Abs(x[1] - 0.01 * x[0] * x[0])) * 100 + 0.01 * Math.Abs(x[0] + 10);
        }
    }
}
