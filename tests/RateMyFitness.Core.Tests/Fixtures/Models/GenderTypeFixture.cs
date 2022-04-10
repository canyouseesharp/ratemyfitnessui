namespace RateMyFitness.Core.Tests.Fixtures.Models
{
	/// <summary>
    /// POCO for serializing data into from JSON 
    /// </summary>
	public class GenderTypeFixture
	{
		public int Id { get; set; }
		public string Label { get; set; } = default!;
	}
}

