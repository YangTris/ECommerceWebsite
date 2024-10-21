namespace ECommerceWebsite.Models
{
	public class Cart
	{
		public string cartId { get; set; }
		public string userId { get; set; }
		public List<CartItem> cartItems { get; set; }
		public decimal total { get; set; }
		public Cart()
		{
			foreach (var item in this.cartItems) 
			{
				total += item.price;
			}
		}
	}
	public class CartItem
	{
		public string cartId { get; set; }
		public AllProductsViewModel product { get; set; }
		public int quantity { get; set; }
		public decimal price { get; set; }
		public CartItem()
		{
			this.price = this.product.price* this.quantity;
		}
	}
}
