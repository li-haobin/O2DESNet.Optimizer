using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.MultiObjective
{
    public class ZDT1 : ZDTx
    {
        public ZDT1(int numberDecisions) : base(numberDecisions)
        {
            Tag = "ZDT1";
        }

        #region Objectives
        public override Vector Evaluate(Vector x)
        {
            if (!this.IsFeasible(x))
                return (DenseVector)new double[] { double.PositiveInfinity, double.PositiveInfinity };
            return new double[] { Get_g1(x), Get_g2(x) }.ToDenseVector();
        }
        protected virtual double Get_g1(Vector x) { return x[0]; }
        protected virtual double Get_g2(Vector x) { return Get_f(x) * Get_h(x); }
        protected virtual double Get_f(Vector x)
        {
            double f = 1.0;
            for (int i = 1; i < NumberDecisions; i++) f += 9 * x[i] / (NumberDecisions - 1);
            return f;
        }
        protected virtual double Get_h(Vector x) { return 1 - Math.Sqrt(Get_g1(x) / Get_f(x)); }
        #endregion

        #region Gradient
        public override Vector[] GetGradients(Vector x)
        {
            return new Vector[] { Get_dg1(x), Get_dg2(x) };
        }
        protected virtual Vector Get_dg1(Vector x)
        {
            var d = new double[NumberDecisions];
            d[0] = 1;
            return (DenseVector)d;
        }
        protected virtual Vector Get_dg2(Vector x)
        {
            return (DenseVector)(Get_f(x) * Get_dh(x) + Get_h(x) * Get_df(x));
        }
        protected virtual Vector Get_df(Vector x)
        {
            var d = x.Select(v => 9.0 / (NumberDecisions - 1)).ToArray();
            d[0] = 0;
            return (DenseVector)d;
        }
        protected virtual Vector Get_dh(Vector x)
        {
            return (DenseVector)(0.5 * (Math.Sqrt(Get_g1(x) / Math.Pow(Get_f(x), 3)) * Get_df(x) - Math.Sqrt(1 / (Get_g1(x) * Get_f(x))) * Get_dg1(x)));
        }
        #endregion
    }
}
