using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;

namespace O2DESNet.Optimizer.MultiObjective
{
    public class ZDT3 : ZDT1
    {
        public ZDT3(int numberDecisions) : base(numberDecisions)
        {
            Tag = "ZDT3";
        }

        protected override double Get_h(IList<double> x)
        {
            return base.Get_h(x) - Get_g1(x) / Get_f(x) * Math.Sin(Kernel(x));
        }
        protected override Vector<double> Get_dh(IList<double> x)
        {
            double kernel = Kernel(x), f = Get_f(x), g1 = Get_g1(x);
            return base.Get_dh(x)
                - (Math.Sin(kernel) + kernel * Math.Cos(kernel)) / f * Get_dg1(x)
                + g1 * Math.Sin(kernel) / (f * f) * Get_df(x);
        }
        private double Kernel(IList<double> x) { return 10 * Math.PI * Get_g1(x); }
    }
}
