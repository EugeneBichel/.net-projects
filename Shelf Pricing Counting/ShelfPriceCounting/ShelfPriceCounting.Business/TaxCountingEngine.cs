using ShelfPriceCounting.Model;

namespace ShelfPriceCounting.Business
{
	/// <summary>
	/// Encapsulates logic for tax calculating.
	/// </summary>
	public sealed class TaxCountingEngine
	{
		// Calculated tax for the product.
		private decimal _calculatedTax;
		// Basic scales tax.
		private readonly int _basicScalesTax;
		// Import tax.
		private readonly int _importTax;

		public TaxCountingEngine(int basicScalesTax, int importTax)
		{
			_calculatedTax = 0M;

			_basicScalesTax = basicScalesTax == 0 ? Constants.BasicSalesTax : basicScalesTax;
			_importTax = importTax == 0 ? Constants.ImportTax : importTax;
		}

		/// <summary>
		/// Adds basic sales tax.
		/// </summary>
		public TaxCountingEngine AddBasicSalesTax(Product originalProduct)
		{
			if (originalProduct.ProductDescription.BasicTaxApplicable)
			{
				_calculatedTax += _basicScalesTax;
			}

			return this;
		}

		/// <summary>
		/// Adds import tax.
		/// </summary>
		public TaxCountingEngine AddImportTax(Product originalProduct)
		{
			if (originalProduct.ProductDescription.Imported)
			{
				_calculatedTax += _importTax;
			}

			return this;
		}

		/// <summary>
		/// Returns tax for the product.
		/// </summary>
		/// <returns>Calculated tax for the product.</returns>
		public decimal ReceiveTax()
		{
			return _calculatedTax;
		}
	}
}
