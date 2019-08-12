using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.SingleObjective
{
    /// <summary>
    /// http://www.sfu.ca/~ssurjano/crossit.html
    /// </summary>
    public class CrossInTray : IEvaluator, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }
        public Vector[] Optimum { get; }

        public CrossInTray(int numberDecisions)
        {
            if (numberDecisions < 2) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("CrossInTray/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-10d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(10d, NumberDecisions).ToDenseVector();
            var zeros = Enumerable.Repeat(0d, NumberDecisions - 2);
            Optimum = new Vector[]
            {
                (DenseVector)new List<double>{ 1.3491, -1.3491 }.Concat(zeros).ToArray(),
                (DenseVector)new List<double>{ 1.3491, 1.3491 }.Concat(zeros).ToArray(),
                (DenseVector)new List<double>{ -1.3491, 1.3491 }.Concat(zeros).ToArray(),
                (DenseVector)new List<double>{ -1.3491, - 1.3491 }.Concat(zeros).ToArray(),
            };
        }

        public double Evaluate(Vector x)
        {
            return -0.0001 * Math.Pow(Math.Abs(Math.Sin(x[0]) * Math.Sin(x[1]) 
                * Math.Exp(Math.Abs(100 - ((DenseVector)x).L2Norm() / Math.PI))) + 1, 0.1);
        }
    }
}
