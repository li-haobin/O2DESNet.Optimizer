using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    /// <summary>
    /// http://www.sfu.ca/~ssurjano/bukin6.html
    /// </summary>
    public class BukinN6 : ISingleObjectiveEvaluator
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }
        
        public BukinN6()
        {
            NumberDecisions = 2;
            Name = string.Format("BukinN6/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-5d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(5d, NumberDecisions).ToList().AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            return Math.Sqrt(Math.Abs(x[1] - 0.01 * x[0] * x[0])) * 100 + 0.01 * Math.Abs(x[0] + 10);
        }
    }
}
