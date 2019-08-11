using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class Rosenbrock : ISingleObjectiveEvaluator, IHasGradient
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }

        public Rosenbrock(int numberDecisions)
        {
            if (numberDecisions < 1) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("Rosenbrock/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToList().AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            double value = 0;
            for (int i = 0; i < x.Count - 1; i++) value += 100 * Math.Pow(x[i + 1] - x[i] * x[i], 2) + Math.Pow(x[i] - 1, 2);
            return value;
        }

        public IList<double> GetGradient(IList<double> x)
        {
            List<double> gradient = new List<double>();
            for (int i = 0; i < x.Count; i++)
            {
                if (i == 0) gradient.Add(-400 * (x[1] - x[0] * x[0]) * x[0] + 2 * x[0] - 2); // any problem?
                else if (i < x.Count - 1) gradient.Add(200 * (x[i] - x[i - 1] * x[i - 1]) - 400 * (x[i + 1] - x[i] * x[i]) * x[i] + 2 * x[i] - 2);
                else gradient.Add(200 * (x[i] - x[i - 1] * x[i - 1]));
            }
            return gradient.ToArray();
        }
    }
}
