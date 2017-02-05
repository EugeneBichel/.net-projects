namespace ShelfPriceCounting.Rounding
{
	/// <summary>
	/// Contract for rounding strategy.
	/// </summary>
	public interface IRoundingStrategy
	{
		decimal RoundTo(decimal value, decimal roundTo);
	}
}
