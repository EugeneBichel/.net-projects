using System.Collections.Generic;

namespace ShelfPriceCounting.Model
{
	public class Receipt
	{
		public int Id { get; set; }
		public IList<Product> Products { get; set; }
		public decimal TotalTax { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
