namespace ShelfPriceCounting.Business
{
	public static class Constants
	{
		/// <summary>
		/// The nearest default value for rounding rules.
		/// </summary>
		public static readonly decimal RoundTo = 0.05M;
		/// <summary>
		/// Basic default sales tax in percantages.
		/// </summary>
		public static readonly int BasicSalesTax = 10;
		/// <summary>
		/// Import default tax in percantages.
		/// </summary>
		public static readonly int ImportTax = 5;
	}
}
