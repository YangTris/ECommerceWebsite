﻿namespace ECommerceWebsite.Models
{
	public class CartItemViewModel
	{
		public string? productId { get; set; }
		public int quantity { get; set; }
		public decimal price { get; set; }
	}
}