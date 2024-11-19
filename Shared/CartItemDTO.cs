﻿namespace Shared
{
	public class CartItemDTO
	{
		public string? productId { get; set; }
		public string? productName { get; set; }
		public int quantity { get; set; }
		public decimal price { get; set; }

		public CartItemDTO(){ }
		public CartItemDTO(string? productId,string? productName, int quantity, decimal price)
		{
			this.productId = productId;
			this.productName = productName;
			this.quantity = quantity;
			this.price = price;
		}
	}
}

