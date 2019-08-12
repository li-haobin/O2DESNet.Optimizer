using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace O2DESNet.Optimizer.MultiObjective
{
    public abstract class ZDTx : IEvaluator, IHasGradients
    {
        public string Tag { get; protected set; }
        public string Name { get { return string.Format("{0}/{1}d", Tag, NumberDecisions); } }
        public int NumberObjectives { get; } = 2;
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }

        public ZDTx(int numberDecisions)
        {
            if (numberDecisions < 2) throw new Exception("The minimum number of decisions for ZDTx is 2.");
            NumberDecisions = numberDecisions;
            LowerBounds = Enumerable.Repeat(0d, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(1d, NumberDecisions).ToDenseVector();
        }

        public abstract Vector Evaluate(Vector decisions);

        public abstract Vector[] GetGradients(Vector decisions);

        public override string ToString() { return Name; }
    }
}
