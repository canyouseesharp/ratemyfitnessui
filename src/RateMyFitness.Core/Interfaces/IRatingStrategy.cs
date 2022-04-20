namespace RateMyFitness.Core.Interfaces
{
    /// <summary>
    /// Strategy pattern interface
    /// </summary>
    public interface IRatingStrategy
    {
        public TResult Rate<TResult>(IRateable rateable) where TResult : IStandard;
    }
}

