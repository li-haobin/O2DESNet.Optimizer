using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective
{
    public class SchafferN2 : IEvaluator, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }
        public Vector[] Optimum { get; }

        public SchafferN2()
        {
            NumberDecisions = 2;
            Name = "SchafferN2";
            LowerBounds = Enumerable.Repeat(-100d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(100d, NumberDecisions).ToDenseVector();
            Optimum = new Vector[] { new double[] { 0, 0 }.ToDenseVector() };
        }

        public double Evaluate(Vector x)
        {
            return 0.5 + (Math.Pow(Math.Sin(x[0] * x[0] - x[1] * x[1]), 2) - 0.5) 
                / Math.Pow(1 + 0.001 * (x[0] * x[0] + x[1] * x[1]), 2);
        }
    }
}
