using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective
{
    public class Perm : IEvaluator, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }
        public Vector[] Optimum { get; }

        public Perm(int numberDecisions)
        {
            if (numberDecisions < 2) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("Perm/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-5d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(5d, NumberDecisions).ToDenseVector();
            Optimum = new Vector[]
            {
                (DenseVector)Enumerable.Range(1, NumberDecisions).Select(i => (double)i).ToArray()
            };
        }

        private const double Beta = 0.5;
        public double Evaluate(Vector x)
        {
            return Enumerable.Range(1, NumberDecisions)
                .Sum(i => Math.Pow(Enumerable.Range(1, NumberDecisions)
                .Sum(j => (Math.Pow(j, i) + Beta) * (Math.Pow(x[j - 1] / j, i) - 1)), 2));
        }
    }
}
