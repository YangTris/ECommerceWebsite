namespace ECommerceWebsite.Models
{
    public class AllProductsViewModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public AllProductsViewModel() { }

		public AllProductsViewModel(string name, string description, decimal price)
		{
			this.name = name;
			this.description = description;
			this.price = price;
		}
	}
}
