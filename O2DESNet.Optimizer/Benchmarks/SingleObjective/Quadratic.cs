using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class Quadratic : ISingleObjectiveEvaluator, IHasGradient
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }

        public Quadratic(int numberDecisions)
        {
            if (numberDecisions < 1) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("Quadratic/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToList().AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            return x.Sum(v => v * v);
        }

        public IList<double> GetGradient(IList<double> x)
        {
            return x.Select(v => v * 2).ToArray();
        }
    }
}
