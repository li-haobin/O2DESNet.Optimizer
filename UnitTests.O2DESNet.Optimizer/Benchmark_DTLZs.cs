using NUnit.Framework;
using O2DESNet.Optimizer.Benchmarks;

namespace UnitTests.O2DESNet.Optimizer
{
    public class Benchmark_DTLZs
    {
        [Test]
        public void Test1()
        {
            var dtlz1 = new DTLZ1(5, 3);
            var res1a = dtlz1.Evaluate(new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 });
            var res1b = dtlz1.Evaluate(new double[] { 0, 0, 0, 0, 0 });
            var zdt2 = new DTLZ2(5, 3);
            var res2 = zdt2.Evaluate(new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 });
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var dtlz1 = new DTLZ1(5, 2);
            var res1a = dtlz1.Evaluate(new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 });
            var res1b = dtlz1.Evaluate(new double[] { 0, 0, 0, 0, 0 });
            var zdt2 = new DTLZ2(5, 2);
            var res2 = zdt2.Evaluate(new double[] { 0.1, 0.2, 0.3, 0.4, 0.5 });
            Assert.Pass();
        }
    }
}