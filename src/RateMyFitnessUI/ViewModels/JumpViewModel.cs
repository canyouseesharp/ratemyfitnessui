using System.ComponentModel.DataAnnotations;
using RateMyFitness.Core.Models;

namespace RateMyFitness.UI.ViewModels
{
	/// <summary>
    /// ViewModel for a submitted jump, allowing easier validation and creation.
    /// </summary>
	public class JumpViewModel
	{
		[Required]
		[Range(4, 100, ErrorMessage = "Your age is outside the acceptable ranges")]
		public int Age { get; set; }

		[Required]
		public string Gender { get; set; } = default!;

		[Required]
		[Range(1, 60, ErrorMessage = "Your measurement is outside the acceptable ranges for a jump")]
		public decimal Measurement { get; set; }

		/// <summary>
		/// Return the rating for this jump.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public Rating GetRating() => throw new NotImplementedException();
	}
}

