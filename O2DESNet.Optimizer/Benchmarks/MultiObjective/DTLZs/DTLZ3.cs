using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.Benchmarks.MultiObjective
{
    public class DTLZ3 : DTLZx
    {
        public DTLZ3(int numberDecisions = 12, int numberObjectives = 3)
            : base(numberDecisions, numberObjectives)
        {
            Tag = "DTLZ3";
        }

        public override IList<double> Evaluate(IList<double> decisions)
        {
            if (!this.IsFeasible(decisions))
                return Enumerable.Repeat(double.PositiveInfinity, NumberObjectives).ToList();

            var x = decisions.ToArray();
            int k = NumberDecisions - NumberObjectives + 1;
            double[] f = new double[NumberObjectives];
            double g = 0.0;
            for (int i = NumberDecisions - k; i < NumberDecisions; i++)
                g += (x[i] - 0.5) * (x[i] - 0.5) - Math.Cos(20.0 * Math.PI * (x[i] - 0.5));
            g = 100.0 * (k + g);
            for (int i = 0; i < NumberObjectives; i++)
                f[i] = 1.0 + g;
            for (int i = 0; i < NumberObjectives; i++)
            {
                for (int j = 0; j < NumberObjectives - (i + 1); j++)
                {
                    f[i] *= Math.Cos(x[j] * 0.5 * Math.PI);
                }
                if (i != 0)
                {
                    int aux = NumberObjectives - (i + 1);
                    f[i] *= Math.Sin(x[aux] * 0.5 * Math.PI);
                }
            }
            return f;
        }
    }
}
