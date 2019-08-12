using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    public class Quadratic : IEvaluator, IHasGradient
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }

        public Quadratic(int numberDecisions)
        {
            if (numberDecisions < 1) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("Quadratic/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToDenseVector();
        }

        public double Evaluate(Vector x)
        {
            return x.Sum(v => v * v);
        }

        public Vector GetGradient(Vector x)
        {
            return x.Select(v => v * 2).ToDenseVector();
        }
    }
}
