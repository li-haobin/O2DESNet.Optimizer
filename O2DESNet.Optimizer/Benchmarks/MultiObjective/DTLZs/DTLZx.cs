using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks
{
    public abstract class DTLZx : IMultiObjectiveEvaluator
    {
        public string Tag { get; protected set; }
        public string Name { get { return string.Format("{0}/{1}d/{2}o", Tag, NumberDecisions, NumberObjectives); } }
        public int NumberObjectives { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }


        public DTLZx(int numberDecisions, int numberObjectives)
        {
            if (numberDecisions < 2) throw new Exception("The minimum number of decisions for DTLZx is 2.");
            if (numberObjectives < 2) throw new Exception("The minimum number of objectives for DTLZx is 2.");
            NumberDecisions = numberDecisions;
            NumberObjectives = numberObjectives;
            LowerBounds = Enumerable.Repeat(0d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(1d, NumberDecisions).ToList().AsReadOnly();
        }

        public abstract IList<double> Evaluate(IList<double> decisions);

        public override string ToString() { return Name; }
    }
}
