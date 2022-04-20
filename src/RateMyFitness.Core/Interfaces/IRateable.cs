namespace RateMyFitness.Core.Interfaces
{
	public interface IRateable
	{
		
	}

	public class Jump : IRateable
    {
		// distance
		// age
		// height
		// weight
		// gender
    }

	public class Lift : IRateable
    {
		// exercise
		// weight lifted
		// age
		// gender
		// weight
    }

	public class Run : IRateable
    {
		// distance
		// time
		// age
		// gender
    }
}