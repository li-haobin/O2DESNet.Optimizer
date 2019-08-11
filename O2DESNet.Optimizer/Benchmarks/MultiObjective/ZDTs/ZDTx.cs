using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

namespace O2DESNet.Optimizer.Benchmarks.MultiObjective
{
    public abstract class ZDTx : IMultiObjectiveEvaluator, IHasMultiGradient
    {
        public string Tag { get; protected set; }
        public string Name { get { return string.Format("{0}/{1}d", Tag, NumberDecisions); } }
        public int NumberObjectives { get; } = 2;
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }

        public ZDTx(int numberDecisions)
        {
            if (numberDecisions < 2) throw new Exception("The minimum number of decisions for ZDTx is 2.");
            NumberDecisions = numberDecisions;
            LowerBounds = Enumerable.Repeat(0d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(1d, NumberDecisions).ToList().AsReadOnly();
        }

        public abstract IList<double> Evaluate(IList<double> decisions);

        public abstract Matrix<double> GetGradient(IList<double> decisions);

        public override string ToString() { return Name; }
    }
}
