using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.StochasticApproximation
{
    public static class FDSA
    {
        /// <summary>
        /// Estimate multi-gradient for multi-objective evaluator
        /// by finite-difference stochastic approximation
        /// </summary>
        public static Vector[] EstimateGradient_FDSA(this MultiObjective.IEvaluator evaluator,
            Vector decisions, double perturbation)
        {
            var g = new List<DenseVector>();
            var x = (DenseVector)decisions;
            if (perturbation <= 0) throw new Exception("The perturbation only takes positive value.");
            for (int i = 0; i < evaluator.NumberDecisions; i++)
            {
                var x1 = (DenseVector)decisions; x1[i] += perturbation;
                var x2 = (DenseVector)decisions; x2[i] -= perturbation;
                if (evaluator.IsFeasible(x1) && evaluator.IsFeasible(x2))
                    g.Add(((DenseVector)evaluator.Evaluate(x1) - (DenseVector)evaluator.Evaluate(x2)) / perturbation / 2);
                else if (evaluator.IsFeasible(x1))
                    g.Add(((DenseVector)evaluator.Evaluate(x1) - (DenseVector)evaluator.Evaluate(x)) / perturbation);
                else
                    g.Add(((DenseVector)evaluator.Evaluate(x) - (DenseVector)evaluator.Evaluate(x2)) / perturbation);
            }
            return DenseMatrix.OfColumnVectors(g).ToRowArrays().Select(row => row.ToDenseVector()).ToArray();
        }

        /// <summary>
        /// Estimate gradient for single-objective evaluator,
        /// by finite-difference stochastic approximation
        /// </summary>
        public static Vector EstimateGradient_FDSA(this SingleObjective.IEvaluator evaluator,
            Vector decisions, double perturbation)
        {
            var g = new List<double>();
            var x = (DenseVector)decisions;
            if (perturbation <= 0) throw new Exception("The perturbation only takes positive value.");
            for (int i = 0; i < evaluator.NumberDecisions; i++)
            {
                var x1 = (DenseVector)decisions; x1[i] += perturbation;
                var x2 = (DenseVector)decisions; x2[i] -= perturbation;
                if (evaluator.IsFeasible(x1) && evaluator.IsFeasible(x2))
                    g.Add((evaluator.Evaluate(x1) - evaluator.Evaluate(x2)) / perturbation / 2);
                else if (evaluator.IsFeasible(x1))
                    g.Add((evaluator.Evaluate(x1) - evaluator.Evaluate(x)) / perturbation);
                else
                    g.Add((evaluator.Evaluate(x) - evaluator.Evaluate(x2)) / perturbation);
            }
            return g.ToDenseVector();
        }
    }
}
