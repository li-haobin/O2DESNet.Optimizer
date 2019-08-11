using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks
{
    public class ZDT2 : ZDT1
    {
        public ZDT2(int numberDecisions) : base(numberDecisions)
        {
            Name = string.Format("ZDT2-{0}d", NumberDecisions);
        }

        protected override double Get_h(IList<double> x)
        {
            return 1 - Math.Pow(Get_g1(x) / Get_f(x), 2);
        }

        protected override Vector<double> Get_dh(IList<double> x)
        {
            return 2 * (Math.Pow(Get_g1(x), 2) / Math.Pow(Get_f(x), 3) * Get_df(x) - Get_g1(x) / Math.Pow(Get_f(x), 2) * Get_dg1(x));
        }
    }
}
