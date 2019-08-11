namespace O2DESNet.Optimizer
{
    public interface IEvaluator
    {
        string Name { get; }
        int NumberObjectives { get; }
        int NumberDecisions { get; }
    }
}
