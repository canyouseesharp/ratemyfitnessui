namespace RateMyFitness.Core.Interfaces
{
    /// <summary>
    /// Intended to wrap around EF Core DbContext so we can inject and mock this interface.
    /// </summary>
    public interface IRatingContext
    {
        public IStandard GetRating(IRateable rateable);
    }
}

