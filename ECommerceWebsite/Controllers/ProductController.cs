using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
	public class ProductController : Controller
	{
		private List<Product> products = new();
		public IActionResult ProductDetails()
		{
			return View();
		}

		public IActionResult AllProducts()
		{
			for (int i = 0; i < 10; i++)
			{
				products.Add(new Product("123"+i, "product"+i, i.ToString(), i.ToString(), i*i*10000, i.ToString(), DateTime.Now));
			}
			return View("AllProducts",products);
		}

	}
}
