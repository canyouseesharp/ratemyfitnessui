using System.ComponentModel.DataAnnotations;
using RateMyFitness.Core.Models.Interfaces;

namespace RateMyFitness.Core.Models.Abstractions
{
	public class Rateable : IEntity
	{
		public int Id { get; protected set; }

		[Required]
		public int Age { get; protected set; }

		[Required]
		public GenderType Gender { get; protected set; } = default!;

		[Required]
		public JumpStandard Standard { get; protected set; } = default!;

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

