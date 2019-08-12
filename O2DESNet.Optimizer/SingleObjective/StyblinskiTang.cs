using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    public class StyblinskiTang : IEvaluator, IHasGradient, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }
        public Vector[] Optimum { get; }

        public StyblinskiTang(int numberDecisions)
        {
            if (numberDecisions < 1) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("StyblinskiTang/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToDenseVector();
            Optimum = new Vector[]
            {
                Enumerable.Range(0, NumberDecisions).Select(i => -2.903534).ToDenseVector(),
            };
        }

        public double Evaluate(Vector x)
        {
            return x.Sum(xi => Math.Pow(xi, 4) - Math.Pow(xi, 2) * 16 + xi * 5) / 2;
        }

        public Vector GetGradient(Vector x)
        {
            return x.Select(xi => 2.0 * xi * xi * xi - 16 * xi + 2.5).ToDenseVector();
        }
    }
}
