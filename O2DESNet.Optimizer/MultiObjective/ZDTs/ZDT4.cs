using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.MultiObjective
{
    public class ZDT4 : ZDT1
    {
        public ZDT4(int numberDecisions) : base(numberDecisions)
        {
            Tag = "ZDT4";
        }

        protected override double Get_f(IList<double> x)
        {
            var xp = 10 * (DenseVector)x - 5;
            return 1 + 10 * (NumberDecisions - 1) + Enumerable.Range(1, NumberDecisions - 1)
                .Sum(i => xp[i] * xp[i] - 10 * Math.Cos(4 * Math.PI * xp[i]));
        }
        protected override Vector<double> Get_df(IList<double> x)
        {
            var xp = 10 * (DenseVector)x - 5;
            return (DenseVector)new List<double> { 0 }.Concat(Enumerable.Range(1, NumberDecisions - 1)
                .Select(i => 20 * xp[i] + 400 * Math.PI * Math.Sin(4 * Math.PI * xp[i])));
        }
    }
}
