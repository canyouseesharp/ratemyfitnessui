namespace RateMyFitness.Core.Tests.Fixtures.Models
{
	/// <summary>
	/// POCO for serializing data into from JSON 
	/// </summary>
	public class JumpStandardFixture
	{
		public int Id { get; set; }
		public int AgeMin { get; set; }
		public int AgeMax { get; set; }
		public int GenderId { get; set; }
		public double MeasurementMin { get; set; }
		public double MeasurementMax { get; set; }
		public int RatingId { get; set; }
	}
}

