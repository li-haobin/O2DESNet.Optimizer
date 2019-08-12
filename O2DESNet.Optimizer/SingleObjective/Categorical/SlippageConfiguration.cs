using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective.Categorical
{
    public class SlippageConfiguration : PerturbedDesigns
    {
        public SlippageConfiguration(int size, double rho, int seed = 0) :
            base(GetTrueMeans(size), GetTrueStandardDeviations(size, rho), seed)
        {
        }
        private static List<double> GetTrueMeans(int size)
        {
            var means = Enumerable.Repeat(2d, size).ToList();
            means[0] = 1;
            return means;
        }
        private static List<double> GetTrueStandardDeviations(int size, double rho)
        {
            var stddevs = Enumerable.Repeat(1d / Math.Sqrt(rho), size).ToList();
            return stddevs;
        }
    }
}
