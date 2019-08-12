using MathNet.Numerics.Distributions;
using MathNet.Numerics.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace O2DESNet.Optimizer.SingleObjective.Categorical
{
    public class PerturbedDesigns : IStochasticEvaluator<int>, ISampleStatistics<int>, IKnownPerformance<int>
    {
        public string Name { get; }
        /// <summary>
        /// Total number of designs
        /// </summary>
        public int Size { get; }
        public Random RandomStream { get; }
        private readonly Random[] Rnd;
        public IReadOnlyDictionary<int, IReadOnlyList<double>> Observations
        {
            get { return ObservationsDict.AsReadOnly(l => (IReadOnlyList<double>)l.AsReadOnly()); }
        }
        private readonly Dictionary<int, List<double>> ObservationsDict = new Dictionary<int, List<double>>();
        public IReadOnlyDictionary<int, double> TrueMeans { get; }
        public IReadOnlyDictionary<int, double> TrueStandardDeviations { get; }
        public IReadOnlyDictionary<int, double> SampleMeans
        {
            get { return Observations.ToDictionary(i => i.Key, i => i.Value.Mean()).AsReadOnly(); }
        }
        public IReadOnlyDictionary<int, double> SampleStandardDeviations
        {
            get { return Observations.ToDictionary(i => i.Key, i => i.Value.StandardDeviation()).AsReadOnly(); }
        }
        public int CountSamples { get; private set; } = 0;

        public PerturbedDesigns(IList<double> trueMeans, IList<double> trueStandardDeviations, int seed = 0)
        {
            Name = string.Format("Perturbed Designs #{0:N}", Guid.NewGuid());
            RandomStream = new Random(seed);
            Size = Math.Min(trueMeans.Count, trueStandardDeviations.Count);
            Rnd = Enumerable.Range(0, Size).Select(i => new Random(RandomStream.Next())).ToArray();
            TrueMeans = Enumerable.Range(0, Size).ToDictionary(i => i, i => trueMeans[i]).AsReadOnly();
            TrueStandardDeviations = Enumerable.Range(0, Size).ToDictionary(i => i, i => trueStandardDeviations[i]).AsReadOnly();
            ObservationsDict = new Dictionary<int, List<double>>();
        }
        public double Evaluate(int design)
        {
            if (design < 0 || design >= TrueMeans.Count) throw new IndexOutOfRangeException();
            var value = Normal.Sample(Rnd[design], TrueMeans[design], TrueStandardDeviations[design]);
            if (!ObservationsDict.ContainsKey(design)) ObservationsDict.Add(design, new List<double>());
            ObservationsDict[design].Add(value);
            CountSamples++;
            return value;
        }
    }
}
