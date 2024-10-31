namespace Shared
{
	public class CartItemDTO
	{
		public string? productId { get; set; }
		public int quantity { get; set; }
		public decimal price { get; set; }
		public CartItemDTO(){ }
		public CartItemDTO(string? productId, int quantity, decimal price)
		{
			this.productId = productId;
			this.quantity = quantity;
			this.price = price;
		}
	}
}

