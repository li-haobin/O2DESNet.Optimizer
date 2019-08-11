using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace O2DESNet.Optimizer.Benchmarks
{
    public class ZDT1 : ZDTx
    {
        public ZDT1(int numberDecisions) : base(numberDecisions)
        {
            Name = string.Format("ZDT1/{0}d", NumberDecisions);
        }

        #region Objectives
        public override IList<double> Evaluate(IList<double> x)
        {
            if (!this.IsFeasible(x))
                return new List<double> { double.PositiveInfinity, double.PositiveInfinity }.AsReadOnly();
            return new List<double> { Get_g1(x), Get_g2(x) }.AsReadOnly();
        }
        protected virtual double Get_g1(IList<double> x) { return x[0]; }
        protected virtual double Get_g2(IList<double> x) { return Get_f(x) * Get_h(x); }
        protected virtual double Get_f(IList<double> x)
        {
            double f = 1.0;
            for (int i = 1; i < NumberDecisions; i++) f += 9 * x[i] / (NumberDecisions - 1);
            return f;
        }
        protected virtual double Get_h(IList<double> x) { return 1 - Math.Sqrt(Get_g1(x) / Get_f(x)); }
        #endregion

        #region Gradient
        public override Matrix<double> GetGradient(IList<double> x)
        {
            return DenseMatrix.OfRowVectors(new Vector<double>[] { Get_dg1(x), Get_dg2(x) });
        }
        protected virtual Vector<double> Get_dg1(IList<double> x)
        {
            var d = new double[NumberDecisions];
            d[0] = 1;
            return (DenseVector)d;
        }
        protected virtual Vector<double> Get_dg2(IList<double> x)
        {
            return Get_f(x) * Get_dh(x) + Get_h(x) * Get_df(x);
        }
        protected virtual Vector<double> Get_df(IList<double> x)
        {
            var d = x.Select(v => 9.0 / (NumberDecisions - 1)).ToArray();
            d[0] = 0;
            return (DenseVector)d;
        }
        protected virtual Vector<double> Get_dh(IList<double> x)
        {
            return 0.5 * (Math.Sqrt(Get_g1(x) / Math.Pow(Get_f(x), 3)) * Get_df(x) - Math.Sqrt(1 / (Get_g1(x) * Get_f(x))) * Get_dg1(x));
        }
        #endregion
    }
}
