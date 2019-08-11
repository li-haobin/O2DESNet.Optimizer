using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks
{
    public class ZDT6 : ZDT2
    {
        public ZDT6(int numberDecisions) : base(numberDecisions)
        {
            Name = string.Format("ZDT6-{0}d", NumberDecisions);
        }

        protected override double Get_g1(IList<double> x)
        {
            return 1 - Math.Exp(-4 * x[0]) * Math.Pow(Math.Sin(6 * Math.PI * x[0]), 6);
        }
        protected override Vector<double> Get_dg1(IList<double> x)
        {
            var kernel = 6 * Math.PI * x[0];
            var d = new double[NumberDecisions];
            d[0] = (-36 * Math.PI * Math.Pow(Math.Sin(kernel), 5) * 
                Math.Cos(kernel) + 4 * Math.Pow(Math.Sin(kernel), 6)) * Math.Exp(-4 * x[0]);
            return (DenseVector)d;
        }
        protected override double Get_f(IList<double> x)
        {
            return 1 + 9 * Math.Pow(Enumerable.Range(1, NumberDecisions - 1).Sum(i => x[i]) 
                / (NumberDecisions - 1), 0.25);
        }
        protected override Vector<double> Get_df(IList<double> x)
        {
            return (DenseVector)new double[] { 0 }.Concat(Enumerable.Range(1, NumberDecisions - 1)
                .Select(i => 9 * 0.25 / (NumberDecisions - 1) * Math.Pow(Enumerable.Range(1, NumberDecisions - 1)
                .Sum(j => x[j]) / (NumberDecisions - 1), -0.75)));
        }
    }
}
