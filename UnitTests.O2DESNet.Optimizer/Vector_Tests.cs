using MathNet.Numerics.LinearAlgebra.Double;
using NUnit.Framework;
using O2DESNet.Optimizer.MultiObjective;
using System.Collections.Generic;

namespace UnitTests.O2DESNet.Optimizer
{
    public class Vector_Tests
    {
        [Test]
        public void Test1()
        {
            var hset = new HashSet<Vector>();
            DenseVector v1 = new double[] { 1, 2 };
            DenseVector v2 = new double[] { 1, 2 };
            hset.Add(v1);
            var check = hset.Contains(v2);
        }

        [Test]
        public void Test2()
        {
            var hset = new HashSet<double[]>();
            var v1 = new double[] { 1, 2 };
            var v2 = new double[] { 1, 2 };
            hset.Add(v1);
            var check = hset.Contains(v2);

        }
    }
}