using System.ComponentModel.DataAnnotations;
using RateMyFitness.Core.Models.Abstractions;

namespace RateMyFitness.Core.Models
{
	/// <summary>
	/// Representation of a user recorded jump.
	/// </summary>
	public class Jump : Rateable
	{
		[Required]
		public double Measurement { get; private set; }

		/// <summary>
		/// Init with required properties.
		/// </summary>
		/// <param name="age">Age of jumper.</param>
		/// <param name="gender">Gender of jumper.</param>
		/// <param name="measurement">Jump measurement.</param>
		/// <param name="standard">Standard for this jump.</param>
		public Jump(int age, GenderType gender, double measurement, JumpStandard standard)
		{
			Age = age;
			Gender = gender;
			Measurement = measurement;
			Standard = standard;
		}

		/// <summary>
		/// For EF Core.
		/// </summary>
		private Jump() { }

		/// <summary>
		/// Return the standard for this jump.
		/// </summary>
		/// <returns></returns>
		public JumpStandard GetStandard() => Standard;
	}
}

