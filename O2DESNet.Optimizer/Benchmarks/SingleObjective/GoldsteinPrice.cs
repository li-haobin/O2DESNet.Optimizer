using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks.SingleObjective
{
    public class GoldsteinPrice : ISingleObjectiveEvaluator, IHasGradient, IKnownOptimum
    {
        public string Name { get; }
        public int NumberDecisions { get; }
        public IReadOnlyList<double> LowerBounds { get; }
        public IReadOnlyList<double> UpperBounds { get; }
        public IReadOnlyList<IReadOnlyList<double>> KnownOptimum { get; }

        public GoldsteinPrice()
        {
            NumberDecisions = 2;
            Name = "GoldsteinPrice";
            LowerBounds = Enumerable.Repeat(-2d, NumberDecisions).ToList().AsReadOnly();
            UpperBounds = Enumerable.Repeat(2d, NumberDecisions).ToList().AsReadOnly();
            KnownOptimum = new List<IReadOnlyList<double>> { new List<double> { 0, -1 }.AsReadOnly() }.AsReadOnly();
        }
        private static double Get_s1(double x1, double x2) { return (x1 + x2 + 1) * (x1 + x2 + 1); }
        private static double Get_s2(double x1, double x2) { return 19 - 14 * x1 + 3 * x1 * x1 - 14 * x2 + 6 * x1 * x2 + 3 * x2 * x2; }
        private static double Get_s3(double x1, double x2) { return (2 * x1 - 3 * x2) * (2 * x1 - 3 * x2); }
        private static double Get_s4(double x1, double x2) { return 18 - 32 * x1 + 12 * x1 * x1 + 48 * x2 - 36 * x1 * x2 + 27 * x2 * x2; }
        private static double Get_t1(double x1, double x2) { return 1 + Get_s1(x1, x2) * Get_s2(x1, x2); }
        private static double Get_t2(double x1, double x2) { return 30 + Get_s3(x1, x2) * Get_s4(x1, x2); }
        private static double Get_ds1dx1(double x1, double x2) { return 2 * (x1 + x2 + 1); }
        private static double Get_ds1dx2(double x1, double x2) { return 2 * (x1 + x2 + 1); }
        private static double Get_ds2dx1(double x1, double x2) { return -14 + 6 * x1 + 6 * x2; }
        private static double Get_ds2dx2(double x1, double x2) { return -14 + 6 * x1 + 6 * x2; }
        private static double Get_ds3dx1(double x1, double x2) { return 4 * (2 * x1 - 3 * x2); }
        private static double Get_ds3dx2(double x1, double x2) { return -6 * (2 * x1 - 3 * x2); }
        private static double Get_ds4dx1(double x1, double x2) { return -32 + 24 * x1 - 36 * x2; }
        private static double Get_ds4dx2(double x1, double x2) { return 48 - 36 * x1 + 54 * x2; }
        private static double Get_dt1dx1(double x1, double x2)
        {
            return Get_s1(x1, x2) * Get_ds2dx1(x1, x2) + Get_ds1dx1(x1, x2) * Get_s2(x1, x2);
        }
        private static double Get_dt1dx2(double x1, double x2)
        {
            return Get_s1(x1, x2) * Get_ds2dx2(x1, x2) + Get_ds1dx2(x1, x2) * Get_s2(x1, x2);
        }
        private static double Get_dt2dx1(double x1, double x2)
        {
            return Get_s3(x1, x2) * Get_ds4dx1(x1, x2) + Get_ds3dx1(x1, x2) * Get_s4(x1, x2);
        }
        private static double Get_dt2dx2(double x1, double x2)
        {
            return Get_s3(x1, x2) * Get_ds4dx2(x1, x2) + Get_ds3dx2(x1, x2) * Get_s4(x1, x2);
        }

        public double Evaluate(IList<double> x)
        {
            double x1 = x[0], x2 = x[1];
            return Get_t1(x1, x2) * Get_t2(x1, x2);
        }

        public IList<double> GetGradient(IList<double> x)
        {
            double x1 = x[0], x2 = x[1];
            return new double[] 
            {
                Get_t1(x1, x2) * Get_dt2dx1(x1, x2) + Get_dt1dx1(x1, x2) * Get_t2(x1, x2),
                Get_t1(x1, x2) * Get_dt2dx2(x1, x2) + Get_dt1dx2(x1, x2) * Get_t2(x1, x2)
            };
        }
    }
}
