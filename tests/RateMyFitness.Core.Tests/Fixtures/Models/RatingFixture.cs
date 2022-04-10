namespace RateMyFitness.Core.Tests.Fixtures.Models
{
	/// <summary>
	/// POCO for serializing data into from JSON 
	/// </summary>
	public class RatingFixture
	{
		public int Id { get; set; }
		public string Description { get; set; } = default!;
	}
}

