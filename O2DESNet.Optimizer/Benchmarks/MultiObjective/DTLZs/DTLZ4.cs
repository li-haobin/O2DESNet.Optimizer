using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.Benchmarks.MultiObjective
{
    public class DTLZ4 : DTLZx
    {
        public DTLZ4(int numberDecisions = 12, int numberObjectives = 3)
            : base(numberDecisions, numberObjectives)
        {
            Tag = "DTLZ4";
        }

        public override IList<double> Evaluate(IList<double> decisions)
        {
            if (!this.IsFeasible(decisions))
                return Enumerable.Repeat(double.PositiveInfinity, NumberObjectives).ToList();

            var x = decisions.ToArray();
            int k = NumberDecisions - NumberObjectives + 1;
            double[] f = new double[NumberObjectives];
            double alpha = 100.0;
            double g = 0.0;
            for (int i = NumberDecisions - k; i < NumberDecisions; i++)
                g += (x[i] - 0.5) * (x[i] - 0.5);
            for (int i = 0; i < NumberObjectives; i++)
                f[i] = 1.0 + g;
            for (int i = 0; i < NumberObjectives; i++)
            {
                for (int j = 0; j < NumberObjectives - (i + 1); j++)
                {
                    f[i] *= Math.Cos(Math.Pow(x[j], alpha) * Math.PI / 2.0);
                }
                if (i != 0)
                {
                    int aux = NumberObjectives - (i + 1);
                    f[i] *= Math.Sin(Math.Pow(x[aux], alpha) * Math.PI / 2.0);
                }
            }
            return f;
        }
    }
}
