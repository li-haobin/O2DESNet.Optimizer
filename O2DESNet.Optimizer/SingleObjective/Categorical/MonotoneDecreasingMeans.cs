using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective.Categorical
{
    public class MonotoneDecreasingMeans : PerturbedDesigns
    {
        public MonotoneDecreasingMeans(int size, double vPower, int seed = 0) :
            base(GetTrueMeans(size), GetTrueStandardDeviations(size, vPower), seed)
        {
        }
        private static List<double> GetTrueMeans(int size)
        {
            var means = Enumerable.Range(1, size).Select(i => (double)i).ToList();
            return means;
        }
        private static List<double> GetTrueStandardDeviations(int size, double vPower)
        {
            double delta = 1;
            var stddevs = Enumerable.Range(1, size).Select(i => Math.Pow(Math.Abs(i - delta) + 1, vPower / 2)).ToList();
            return stddevs;
        }
    }
}
