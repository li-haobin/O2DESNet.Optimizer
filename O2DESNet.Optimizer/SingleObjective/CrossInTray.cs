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
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }
        public IReadOnlyList<IReadOnlyList<double>> Optimum { get; }

        public CrossInTray(int numberDecisions)
        {
            if (numberDecisions < 2) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            Name = string.Format("CrossInTray/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-10d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(10d, NumberDecisions).ToList().AsReadOnly();
            var zeros = Enumerable.Repeat(0d, NumberDecisions - 2);
            Optimum = new List<IReadOnlyList<double>>
            {
                new List<double>{ 1.3491, -1.3491 }.Concat(zeros).ToList().AsReadOnly(),
                new List<double>{ 1.3491, 1.3491 }.Concat(zeros).ToList().AsReadOnly(),
                new List<double>{ -1.3491, 1.3491 }.Concat(zeros).ToList().AsReadOnly(),
                new List<double>{ -1.3491, - 1.3491 }.Concat(zeros).ToList().AsReadOnly(),
            }.AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            return -0.0001 * Math.Pow(Math.Abs(Math.Sin(x[0]) * Math.Sin(x[1]) 
                * Math.Exp(Math.Abs(100 - ((DenseVector)x).L2Norm() / Math.PI))) + 1, 0.1);
        }
    }
}
