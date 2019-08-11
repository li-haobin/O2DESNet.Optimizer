using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.Benchmarks.MultiObjective
{
    public class MultiSphere : IMultiObjectiveEvaluator, IHasMultiGradient
    {
        public string Name { get; }
        public int NumberObjectives { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }

        public IReadOnlyList<IReadOnlyList<double>> Optima { get; }

        public MultiSphere(params IList<double>[] optima)
        {
            NumberDecisions = optima.Min(o => o.Count);
            NumberObjectives = optima.Length;
            Name = string.Format("MultiSphere/{0}d/{1}o", NumberDecisions, NumberObjectives); 
            Optima = optima.Select(o => o.Take(NumberDecisions).ToList().AsReadOnly()).ToList().AsReadOnly();
            LowerBounds = Enumerable.Repeat(double.NegativeInfinity, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(double.PositiveInfinity, NumberDecisions).ToList().AsReadOnly();
        }

        public IList<double> Evaluate(IList<double> decisions)
        {
            return Enumerable.Range(0, NumberObjectives)
                .Select(o => Enumerable.Range(0, NumberDecisions)
                .Sum(d => Math.Pow(decisions[d] - Optima[o][d], 2))).ToList();
        }

        public Matrix<double> GetGradient(IList<double> decisions)
        {
            return DenseMatrix.OfRowVectors(Optima.Select(o => 2 * ((DenseVector)decisions - (DenseVector)o)));
        }
    }
}
