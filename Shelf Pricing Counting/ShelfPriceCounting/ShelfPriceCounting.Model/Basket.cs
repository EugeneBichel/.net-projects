using System.Collections.Generic;

namespace ShelfPriceCounting.Model
{
	public class Basket
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public IList<Product> Products { get; set; }
	}
}
