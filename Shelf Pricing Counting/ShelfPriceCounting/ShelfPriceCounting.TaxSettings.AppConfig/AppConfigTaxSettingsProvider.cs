using System;
using System.Configuration;

namespace ShelfPriceCounting.TaxSettings.AppConfig
{
	/// <summary>
	/// Uses app.config as a tax settings storage.
	/// </summary>
	public class AppConfigTaxSettingsProvider : ITaxSettingsProvider
	{
		public readonly string RoundToKey = "RoundTo";
		public readonly string BasicSalesTaxKey = "BasicSalesTax";
		public readonly string ImportTaxKey = "ImportTax";

		public TaxContext GetTaxContext()
		{
			var taxContext = new TaxContext();

			decimal roundToValue;
			if (decimal.TryParse(ConfigurationManager.AppSettings[RoundToKey], out roundToValue))
			{
				taxContext.RoundTo = roundToValue;
			}

			int basicScalesTaxValue;
			if (int.TryParse(ConfigurationManager.AppSettings[BasicSalesTaxKey], out basicScalesTaxValue))
			{
				taxContext.BasicSalesTax = basicScalesTaxValue;
			}

			int importTaxValue;
			if (int.TryParse(ConfigurationManager.AppSettings[ImportTaxKey], out importTaxValue))
			{
				taxContext.ImportTax = importTaxValue;
			}

			return taxContext;
		}

		public void SetTaxContext(TaxContext taxContext)
		{
			throw new NotImplementedException();
		}
	}
}
