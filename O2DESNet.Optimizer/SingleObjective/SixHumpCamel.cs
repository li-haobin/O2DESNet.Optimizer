using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    public class SixHumpCamel : IEvaluator, IHasGradient, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }
        public IReadOnlyList<IReadOnlyList<double>> Optimum { get; }

        public SixHumpCamel()
        {
            NumberDecisions = 2;
            Name = "SixHumpCamel";
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToList().AsReadOnly();
            Optimum = new List<IReadOnlyList<double>>
            {
                new List<double> { 0.0898, -0.7126 }.AsReadOnly(),
                new List<double> { -0.0898, 0.7126 }.AsReadOnly(),
            }.AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            double x1 = x[0], x2 = x[1];
            return (4 - 2.1 * x1 * x1 + x1 * x1 * x1 * x1 / 3) * x1 * x1 + x1 * x2 + (-4 + 4 * x2 * x2) * x2 * x2;
        }

        public IList<double> GetGradient(IList<double> x)
        {
            double x1 = x[0], x2 = x[1];
            return new double[] {
                8 * x1 - 8.4 * x1 * x1 * x1 + 2 * x1 * x1 * x1 * x1 * x1 + x2,
                x1 - 8 * x2 + 16 * x2 * x2 * x2
            };
        }
    }
}
