using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class Product
	{
		public ObjectId productId { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public string category { get; set; } 
		public decimal price { get; set; }
		public string imageUrl { get; set; }
		public DateTime timestamp { get; set; }

		public Product() { }

		public Product(ObjectId productId, string name, string description, string category, decimal price, string imageUrl, DateTime timestamp)
		{
			this.productId = productId;
			this.name = name;
			this.description = description;
			this.category = category;
			this.price = price;
			this.imageUrl = imageUrl;
			this.timestamp = timestamp;
		}
	}
}
