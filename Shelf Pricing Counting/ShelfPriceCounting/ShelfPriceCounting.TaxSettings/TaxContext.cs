namespace ShelfPriceCounting.TaxSettings
{
	public class TaxContext
	{
		public int BasicSalesTax { get; set; }
		public int ImportTax { get; set; }
		public decimal RoundTo { get; set; }
	}
}
