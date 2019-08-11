using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class StyblinskiTang : ISingleObjectiveEvaluator, IHasGradient, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }
        public IReadOnlyList<IReadOnlyList<double>> KnownOptimum { get; }

        public StyblinskiTang(int numberDecisions)
        {
            if (numberDecisions < 1) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("StyblinskiTang/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToList().AsReadOnly();
            KnownOptimum = new List<IReadOnlyList<double>>
            {
                Enumerable.Range(0, NumberDecisions).Select(i => -2.903534).ToList().AsReadOnly(),
            }.AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            return x.Sum(xi => Math.Pow(xi, 4) - Math.Pow(xi, 2) * 16 + xi * 5) / 2;
        }

        public IList<double> GetGradient(IList<double> x)
        {
            return x.Select(xi => 2.0 * xi * xi * xi - 16 * xi + 2.5).ToArray();
        }
    }
}
