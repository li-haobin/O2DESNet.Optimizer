using MathNet.Numerics.LinearAlgebra.Double;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective
{
    public class SixHumpCamel : IEvaluator, IHasGradient, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }
        public Vector[] Optimum { get; }

        public SixHumpCamel()
        {
            NumberDecisions = 2;
            Name = "SixHumpCamel";
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToDenseVector();
            Optimum = new Vector[]
            {
                new double[] { 0.0898, -0.7126 }.ToDenseVector(),
                new double[] { -0.0898, 0.7126 }.ToDenseVector(),
            };
        }

        public double Evaluate(Vector x)
        {
            double x1 = x[0], x2 = x[1];
            return (4 - 2.1 * x1 * x1 + x1 * x1 * x1 * x1 / 3) * x1 * x1 + x1 * x2 + (-4 + 4 * x2 * x2) * x2 * x2;
        }

        public Vector GetGradient(Vector x)
        {
            double x1 = x[0], x2 = x[1];
            return new double[] {
                8 * x1 - 8.4 * x1 * x1 * x1 + 2 * x1 * x1 * x1 * x1 * x1 + x2,
                x1 - 8 * x2 + 16 * x2 * x2 * x2
            }.ToDenseVector();
        }
    }
}
