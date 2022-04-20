using System.ComponentModel.DataAnnotations;
using RateMyFitness.Core.Interfaces;

namespace RateMyFitness.Core.Models
{
	/// <summary>
	/// Represents a standard for a jump based on age, gender and measurement.
	/// </summary>
    public class JumpStandard : IEntity, IStandard
	{
		public int Id { get; private set; }

		[Required]
		public int AgeMin { get; private set; }
		[Required]
		public int AgeMax { get; private set; }
		[Required]
		public GenderType Gender { get; private set; } = default!;
		[Required]
		public double MeasurementMin { get; private set; }
		[Required]
		public double MeasurementMax { get; private set; }
		[Required]
		public Rating Rating { get; private set; } = default!;

		/// <summary>
		/// Init with required properties.
		/// </summary>
		/// <param name="ageMin">Minimum range for age of user.</param>
		/// <param name="ageMax">Maximum range for age of user.</param>
		/// <param name="gender">Gender of user.</param>
		/// <param name="measurementMin">Minimum measurement range for this rating.</param>
		/// <param name="measurementMax">Maximum measurement range for this rating.</param>
		/// <param name="rating">Rating for this jump.</param>
		public JumpStandard(int ageMin, int ageMax, GenderType gender, double measurementMin, double measurementMax, Rating rating)
		{
			AgeMin = ageMin;
			AgeMax = ageMax;
			Gender = gender;
			MeasurementMin = measurementMin;
			MeasurementMax = measurementMax;
			Rating = rating;
		}

		/// <summary>
		/// For EF Core.
		/// </summary>
		private JumpStandard() { }

		/// <summary>
		/// Set the Id, unless it exists already.
		/// </summary>
		/// <param name="id">Id to set.</param>
		/// <exception cref="InvalidOperationException"></exception>
		public void SetId(int id)
		{
			if (Id > 0)
			{
				throw new InvalidOperationException($"Id for this entity already exists: {Id}");
			}
			Id = id;
		}

		/// <summary>
        /// Get the rating for this standard.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Rating GetRating()
        {
            throw new NotImplementedException();
        }
    }
}

