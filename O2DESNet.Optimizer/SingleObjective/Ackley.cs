using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    /// <summary>
    /// http://www.sfu.ca/~ssurjano/ackley.html
    /// </summary>
    public class Ackley : IEvaluator
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }

        private const double A = 20, B = 0.2, C = Math.PI * 2;

        public Ackley(int numberDecisions)
        {
            if (numberDecisions < 1) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("Ackley/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-10d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(10d, NumberDecisions).ToDenseVector();
        }

        public double Evaluate(Vector x)
        {
            return -A * Math.Exp(-B * Math.Sqrt(x.Average(xi => xi * xi))) - Math.Exp(x.Average(xi => Math.Cos(C * xi))) + A + Math.Exp(1);
        }
    }
}
