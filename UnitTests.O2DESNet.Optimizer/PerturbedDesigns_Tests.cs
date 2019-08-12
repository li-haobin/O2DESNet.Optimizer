using MathNet.Numerics.LinearAlgebra.Double;
using NUnit.Framework;
using O2DESNet.Optimizer.MultiObjective;
using O2DESNet.Optimizer.SingleObjective;
using System.Collections.Generic;

namespace UnitTests.O2DESNet.Optimizer
{
    public class PerturbedDesigns_Tests
    {
        [Test]
        public void Test1()
        {
            var pd = new PerturbedDesigns(
                new double[] { 0, 1, 2, 3, 4, 5 }, 
                new double[] { 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 }
                );
            pd.Evaluate(0);
            pd.Evaluate(0);
            pd.Evaluate(3);
            pd.Evaluate(1);
            pd.Evaluate(2);
        }

    }
}