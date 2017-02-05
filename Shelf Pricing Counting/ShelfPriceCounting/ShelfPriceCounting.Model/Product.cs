namespace ShelfPriceCounting.Model
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Count { get; set; }
		public ProductDescription ProductDescription { get; set; }
	}
}
