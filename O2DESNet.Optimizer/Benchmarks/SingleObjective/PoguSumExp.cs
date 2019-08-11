using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class PoguSumExp : ISingleObjectiveEvaluator, IHasGradient
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public int NEXP { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }

        public PoguSumExp(int numberDecisions)
        {
            if (numberDecisions < 2) throw new NotImplementedException();
            NumberDecisions = numberDecisions;
            NEXP = NumberDecisions / 2;
            Name = string.Format("PoguSumExp/{0}d", NumberDecisions);
            LowerBounds = Enumerable.Repeat(-5d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(5d, NumberDecisions).ToList().AsReadOnly();
        }

        public double Evaluate(IList<double> x)
        {
            double value = 0;
            for (int j = 1; j <= 41; j++) value += Math.Pow(Inner(x, j), 2);
            return value / 41;
        }

        public IList<double> GetGradient(IList<double> x)
        {
            List<double> gradient = new List<double>();
            for (int i = 1; i <= NEXP * 2; i++)
            {
                double gi = 0;
                for (int j = 1; j <= 41; j++)
                {
                    double inn = Inner(x, j);
                    double innerP = InnerPartialDerivative(x, i, j);

                    gi += 2 * inn * innerP;
                    //gi = Math.Min(double.MaxValue, gi); 
                    //gi = Math.Max(double.MinValue, gi);
                }

                gradient.Add(gi / 41);
            }
            if (gradient.Count < NumberDecisions) gradient.Add(0);
            return gradient.ToArray();
        }

        private double Get_t(int j) { return 0.025 * (j - 1); }
        private double Get_y(int j) { return 1 + Math.Log(1 + Get_t(j)); }
        private double Inner(IList<double> x, int j)
        {
            double inner = Get_y(j);
            double tj = Get_t(j);
            for (int i = 1; i <= NEXP; i++) inner -= x[2 * i - 2] * Math.Exp(x[2 * i - 1] * tj);
            return inner;
        }
        private double InnerPartialDerivative(IList<double> x, int i, int j)
        {
            if (i % 2 == 0) return -x[i - 2] * Get_t(j) * Math.Exp(x[i - 1] * Get_t(j));
            else return -Math.Exp(x[i] * Get_t(j));
        }
    }
}
