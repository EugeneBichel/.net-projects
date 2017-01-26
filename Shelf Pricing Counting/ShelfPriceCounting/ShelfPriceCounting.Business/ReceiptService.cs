using System.Collections.Generic;
using ShelfPriceCounting.DAL;
using ShelfPriceCounting.Model;
using ShelfPriceCounting.Rounding;
using ShelfPriceCounting.TaxSettings;

namespace ShelfPriceCounting.Business
{
	/// <summary>
	/// Service for receipts.
	/// </summary>
    public class ReceiptService
	{
		private readonly IRoundingStrategy _roundingStrategy;
	    private readonly IBasketRepository _basketRepository;
		private readonly TaxContext _taxContext;

		/// <summary>
		/// Service for receipts.
		/// </summary>
		/// <param name="roundingStrategy">Registered rounding strategy.</param>
		/// <param name="basketRepository">Registered basket repository.</param>
		/// /// <param name="taxSettingsProvider">Registered tax settings provider.</param>
		public ReceiptService(IRoundingStrategy roundingStrategy, 
			IBasketRepository basketRepository,
			ITaxSettingsProvider taxSettingsProvider)
		{
			_roundingStrategy = roundingStrategy;
			_basketRepository = basketRepository;

			_taxContext = taxSettingsProvider.GetTaxContext() ?? new TaxContext
			{
				BasicSalesTax = Constants.BasicSalesTax,
				ImportTax = Constants.ImportTax,
				RoundTo = Constants.RoundTo
			};
		}

		/// <summary>
		/// Returns a receipt based on the basket, tax rules and rounding strategy.
		/// </summary>
		/// <param name="basketId">Requested basket.</param>
		/// <returns></returns>
		public Receipt GetReceipt(int basketId)
		{
			var requiredBasket = _basketRepository.GetBasket(basketId);
			var receipt = GenerateReceipt(requiredBasket);

			return receipt;
		}

		/// <summary>
		/// Returns receipts based on baskets, tax rules and rounding strategy.
		/// </summary>
		/// <returns>Generated receits</returns>
		public IList<Receipt> GetReceipts()
		{
			var baskets = _basketRepository.GetBaskets();
			var receipts = new List<Receipt>();

			var receiptCounter = 0;

			foreach(var basket in baskets)
			{
				var receipt = GenerateReceipt(basket);
				receipt.Id = receiptCounter++;

				receipts.Add(receipt);
			}

			return receipts;
		}

		private Receipt GenerateReceipt(Basket basket)
	    {
		    var receipt = new Receipt {Products = new List<Product>()};

			var roundTo = _taxContext.RoundTo == 0 ? Constants.RoundTo : _taxContext.RoundTo;

			foreach (var product in basket.Products)
			{
				//calculates tax
				decimal calculatedTax = new TaxCountingEngine(_taxContext.BasicSalesTax, _taxContext.ImportTax)
					.AddBasicSalesTax(product)
					.AddImportTax(product)
					.ReceiveTax();

				var taxFractional = calculatedTax / 100;
				var priceWithTax = product.Price * product.Count * taxFractional;

				//rounded tax
				var roundedTax = _roundingStrategy.RoundTo(priceWithTax, roundTo);

				//fills in receipt details
				receipt.TotalTax += roundedTax;
				product.Price = (product.Price + roundedTax) * product.Count;
				receipt.TotalPrice += product.Price;

				receipt.Products.Add(product);
			}

		    return receipt;
	    }
    }
}
