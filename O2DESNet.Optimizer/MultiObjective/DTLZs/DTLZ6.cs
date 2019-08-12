﻿using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Linq;

namespace O2DESNet.Optimizer.MultiObjective
{
    public class DTLZ6 : DTLZx
    {
        public DTLZ6(int numberDecisions = 12, int numberObjectives = 3)
            : base(numberDecisions, numberObjectives)
        {
            Tag = "DTLZ6";
        }

        public override Vector Evaluate(Vector decisions)
        {
            if (!this.IsFeasible(decisions))
                return Enumerable.Repeat(double.PositiveInfinity, NumberObjectives).ToDenseVector();

            var x = decisions.ToArray();
            int k = NumberDecisions - NumberObjectives + 1;
            DenseVector f = new double[NumberObjectives];
            double[] theta = new double[NumberObjectives - 1];
            double g = 0.0;
            for (int i = NumberDecisions - k; i < NumberDecisions; i++)
                g += Math.Pow(x[i], 0.1);
            double t = Math.PI / (4.0 * (1.0 + g));
            theta[0] = x[0] * Math.PI / 2.0;
            for (int i = 1; i < NumberObjectives - 1; i++)
                theta[i] = t * (1.0 + 2.0 * g * x[i]);
            for (int i = 0; i < NumberObjectives; i++)
                f[i] = 1.0 + g;
            for (int i = 0; i < NumberObjectives; i++)
            {
                for (int j = 0; j < NumberObjectives - (i + 1); j++)
                    f[i] *= Math.Cos(theta[j]);
                if (i != 0)
                {
                    int aux = NumberObjectives - (i + 1);
                    f[i] *= Math.Sin(theta[aux]);
                }
            }
            return f;
        }
    }
}