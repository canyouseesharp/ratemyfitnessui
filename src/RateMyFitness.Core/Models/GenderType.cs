using RateMyFitness.Core.Models.Interfaces;

namespace RateMyFitness.Core.Models
{
	/// <summary>
	/// Represents a Gender Type.
	/// </summary>
	public class GenderType : IEntity
	{
		public int Id { get; private set; }
		public string Label { get; private set; } = default!;

		/// <summary>
		/// Init with required properties.
		/// </summary>
		/// <param name="label">Gender label/name.</param>
		public GenderType(string label) => Label = label;

		/// <summary>
		/// For EF Core.
		/// </summary>
		private GenderType() { }

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

