using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Linq;

namespace O2DESNet.Optimizer.MultiObjective
{
    public abstract class DTLZx : IEvaluator
    {
        public string Tag { get; protected set; }
        public string Name { get { return string.Format("{0}/{1}d/{2}o", Tag, NumberDecisions, NumberObjectives); } }
        public int NumberObjectives { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }


        public DTLZx(int numberDecisions, int numberObjectives)
        {
            if (numberDecisions < 2) throw new Exception("The minimum number of decisions for DTLZx is 2.");
            if (numberObjectives < 2) throw new Exception("The minimum number of objectives for DTLZx is 2.");
            NumberDecisions = numberDecisions;
            NumberObjectives = numberObjectives;
            LowerBounds = Enumerable.Repeat(0d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(1d, NumberDecisions).ToDenseVector();
        }

        public abstract Vector Evaluate(Vector decisions);

        public override string ToString() { return Name; }
    }
}
