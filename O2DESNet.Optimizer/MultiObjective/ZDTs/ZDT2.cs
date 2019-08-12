using MathNet.Numerics.LinearAlgebra.Double;
using System;

namespace O2DESNet.Optimizer.MultiObjective
{
    public class ZDT2 : ZDT1
    {
        public ZDT2(int numberDecisions) : base(numberDecisions)
        {
            Tag = "ZDT2";
        }

        protected override double Get_h(Vector x)
        {
            return 1 - Math.Pow(Get_g1(x) / Get_f(x), 2);
        }

        protected override Vector Get_dh(Vector x)
        {
            return (2 * (Math.Pow(Get_g1(x), 2) / Math.Pow(Get_f(x), 3) * Get_df(x) 
                - Get_g1(x) / Math.Pow(Get_f(x), 2) * Get_dg1(x))).ToDenseVector();
        }
    }
}
