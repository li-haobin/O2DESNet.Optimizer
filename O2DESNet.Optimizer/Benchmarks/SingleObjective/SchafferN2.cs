using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class SchafferN2 : ISingleObjectiveEvaluator, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }
        public IReadOnlyList<IReadOnlyList<double>> KnownOptimum { get; }

        public SchafferN2()
        {
            NumberDecisions = 2;
            Name = "SchafferN2";
            LowerBounds = Enumerable.Repeat(-100d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(100d, NumberDecisions).ToList().AsReadOnly();
            KnownOptimum = new List<IReadOnlyList<double>>
            {
                new List<double>{ 0, 0 }.AsReadOnly(),
            }.AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            return 0.5 + (Math.Pow(Math.Sin(x[0] * x[0] - x[1] * x[1]), 2) - 0.5) 
                / Math.Pow(1 + 0.001 * (x[0] * x[0] + x[1] * x[1]), 2);
        }
    }
}
