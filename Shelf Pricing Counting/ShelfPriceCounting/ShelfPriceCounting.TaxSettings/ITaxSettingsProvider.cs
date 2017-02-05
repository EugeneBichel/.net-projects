namespace ShelfPriceCounting.TaxSettings
{
	/// <summary>
	/// Contract for tax settings providing.
	/// </summary>
	public interface ITaxSettingsProvider
	{
		TaxContext GetTaxContext();
		 void SetTaxContext(TaxContext taxContext);
	}
}
