using MathNet.Numerics.LinearAlgebra.Double;
using NUnit.Framework;
using O2DESNet.Optimizer.MultiObjective;

namespace UnitTests.O2DESNet.Optimizer
{
    public class Benchmark_ZDTs
    {
        [Test]
        public void Test1()
        {
            var zdt1 = new ZDT1(5);
            var res1a = zdt1.Evaluate((DenseVector)new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 });
            var res1b = zdt1.Evaluate((DenseVector)new double[] { 0, 0, 0, 0, 0 });
            var zdt2 = new ZDT2(5);
            var res2 = zdt2.Evaluate((DenseVector)new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 });
            Assert.Pass();
        }
    }
}