using NUnit.Framework;
using O2DESNet.Optimizer.SingleObjective.Categorical;
using System;

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

        [Test]
        public void Test2()
        {
            var sc = new SlippageConfiguration(10, 2);
            var rs = new Random(0);
            for(int i = 0; i < 1000; i++)
            {
                sc.Evaluate(rs.Next(sc.Size));
            }
        }

        [Test]
        public void Test3()
        {
            var mdm = new MonotoneDecreasingMeans(10, 2);
            var rs = new Random(0);
            for (int i = 0; i < 1000; i++)
            {
                mdm.Evaluate(rs.Next(mdm.Size));
            }
        }

    }
}