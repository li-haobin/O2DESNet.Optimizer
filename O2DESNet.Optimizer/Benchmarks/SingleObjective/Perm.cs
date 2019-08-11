using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class Perm : ISingleObjectiveEvaluator, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }
        public IReadOnlyList<IReadOnlyList<double>> KnownOptimum { get; }

        public Perm(int numberDecisions)
        {
            if (numberDecisions < 2) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("Perm/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-5d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(5d, NumberDecisions).ToList().AsReadOnly();
            KnownOptimum = new List<IReadOnlyList<double>>
            {
                Enumerable.Range(1, NumberDecisions).Select(i => (double)i).ToList().AsReadOnly()
            }.AsReadOnly();
        }

        private const double Beta = 0.5;
        public double Evaluate(IList<double> x)
        {
            return Enumerable.Range(1, NumberDecisions)
                .Sum(i => Math.Pow(Enumerable.Range(1, NumberDecisions)
                .Sum(j => (Math.Pow(j, i) + Beta) * (Math.Pow(x[j - 1] / j, i) - 1)), 2));
        }
    }
}
