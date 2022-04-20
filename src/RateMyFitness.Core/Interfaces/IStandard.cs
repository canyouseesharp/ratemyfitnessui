using RateMyFitness.Core.Models;

namespace RateMyFitness.Core.Interfaces
{
	/// <summary>
    /// Represents a fitness standard
    /// </summary>
	public interface IStandard
	{
		public Rating GetRating();
	}
}

