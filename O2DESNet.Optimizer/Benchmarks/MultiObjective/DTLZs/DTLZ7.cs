using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.Benchmarks.MultiObjective
{
    public class DTLZ7 : DTLZx
    {
        public DTLZ7(int numberDecisions = 12, int numberObjectives = 3)
            : base(numberDecisions, numberObjectives)
        {
            Tag = "DTLZ7";
        }

        public override IList<double> Evaluate(IList<double> decisions)
        {
            if (!this.IsFeasible(decisions))
                return Enumerable.Repeat(double.PositiveInfinity, NumberObjectives).ToList().AsReadOnly();

            var x = decisions.ToArray();
            int k = NumberDecisions - NumberObjectives + 1;
            double[] f = new double[NumberObjectives];
            double[] theta = new double[NumberObjectives - 1];
            double g = 0.0;
            for (int i = NumberDecisions - k; i < NumberDecisions; i++)
                g += x[i];
            g = 1 + (9.0 * g) / k;
            for (int i = 0; i < NumberObjectives - 1; i++)
                f[i] = x[i];
            double h = 0.0;
            for (int i = 0; i < NumberObjectives - 1; i++)
                h += (f[i] / (1.0 + g)) * (1 + Math.Sin(3.0 * Math.PI * f[i]));
            h = NumberObjectives - h;
            f[NumberObjectives - 1] = (1 + g) * h;
            return f;
        }
    }
}
