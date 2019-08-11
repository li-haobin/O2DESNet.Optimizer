using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class Shubert : ISingleObjectiveEvaluator
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }

        public Shubert()
        {
            NumberDecisions = 2;
            Name = "Shubert";
            LowerBounds = Enumerable.Repeat(-10d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(10d, NumberDecisions).ToList().AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            var indices = Enumerable.Range(0, 5);
            return indices.Sum(i => Math.Cos(x[0] * (i + 1) + i) * i) * indices.Sum(i => Math.Cos(x[1] * (i + 1) + i) * i);
        }
    }
}
