using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective
{
    public class Shubert : IEvaluator
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }

        public Shubert()
        {
            NumberDecisions = 2;
            Name = "Shubert";
            LowerBounds = Enumerable.Repeat(-10d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(10d, NumberDecisions).ToDenseVector();
        }

        public double Evaluate(Vector x)
        {
            var indices = Enumerable.Range(0, 5);
            return indices.Sum(i => Math.Cos(x[0] * (i + 1) + i) * i) * indices.Sum(i => Math.Cos(x[1] * (i + 1) + i) * i);
        }
    }
}
