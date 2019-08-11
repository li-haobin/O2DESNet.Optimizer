using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.LinearAlgebra;

namespace O2DESNet.Optimizer.Benchmarks
{
    public abstract class ZDTx : IMultiObjectiveEvaluator, IHasMultiGradient
    {
        public string Name { get; protected set; }
        public int NumberObjectives { get; } = 2;
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }

        public ZDTx(int numberDecisions)
        {
            NumberDecisions = numberDecisions;
            LowerBounds = Enumerable.Repeat(0d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(1d, NumberDecisions).ToList().AsReadOnly();
        }

        public abstract IList<double> Evaluate(IList<double> decisions);

        public abstract Matrix<double> GetGradient(IList<double> decisions);

        public override string ToString() { return Name; }
    }
}
