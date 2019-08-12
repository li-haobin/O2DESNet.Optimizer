using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.MultiObjective
{
    public class MultiSphere : IEvaluator, IHasGradients, IKnownOptimum
    {
        public string Name { get; }
        public int NumberObjectives { get; }
        public int NumberDecisions { get; }
        public Vector LowerBounds { get; }
        public Vector UpperBounds { get; }

        public Vector[] Optimum { get; }

        public MultiSphere(params Vector[] optimum)
        {
            NumberDecisions = optimum.Min(o => o.Count);
            NumberObjectives = optimum.Length;
            Name = string.Format("MultiSphere/{0}d/{1}o", NumberDecisions, NumberObjectives);
            Optimum = optimum.Select(o => (DenseVector) o.Take(NumberDecisions).ToArray()).ToArray();
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToDenseVector();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToDenseVector();
        }

        public Vector Evaluate(Vector decisions)
        {
            return Enumerable.Range(0, NumberObjectives)
                .Select(o => Enumerable.Range(0, NumberDecisions)
                .Sum(d => Math.Pow(decisions[d] - Optimum[o][d], 2))).ToDenseVector();
        }

        public Vector[] GetGradients(Vector decisions)
        {
            return Optimum.Select(o => (2 * (decisions - o)).ToDenseVector()).ToArray();
        }
    }
}
