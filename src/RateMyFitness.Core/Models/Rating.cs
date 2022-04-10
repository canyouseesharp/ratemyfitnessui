using System.ComponentModel.DataAnnotations;
using RateMyFitness.Core.Models.Interfaces;

namespace RateMyFitness.Core.Models
{
	public class Rating : IEntity
	{
		public int Id { get; private set; }

		[Required]
		public string Description { get; private set; } = default!;

		/// <summary>
		/// Init with required properties.
		/// </summary>
		/// <param name="description">Description for this rating.</param>
		public Rating(string description) => Description = description;

		/// <summary>
		/// For EF Core.
		/// </summary>
		private Rating() { }

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
	}
}

