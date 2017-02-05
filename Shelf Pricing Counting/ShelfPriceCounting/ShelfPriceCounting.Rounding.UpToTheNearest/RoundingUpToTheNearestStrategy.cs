using System;

namespace ShelfPriceCounting.Rounding.UpToTheNearest
{
	/// <summary>
	/// Rounding up the nearest strategy.
	/// </summary>
	public class RoundingUpToTheNearestStrategy : IRoundingStrategy
	{
		public decimal RoundTo(decimal value, decimal roundTo)
		{
			if (roundTo == decimal.Zero)
				return value;

			return Math.Ceiling(value / roundTo) * roundTo;
		}
	}
}
