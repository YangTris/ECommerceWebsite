namespace Shared
{
    public class ProductDTO
    {
		public string productId { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public decimal price { get; set; }
		public string imageUrl { get; set; }
		public DateTime timestamp { get; set; }
	}
}
