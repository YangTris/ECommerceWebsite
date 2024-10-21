using ECommerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using System.Collections;

namespace ECommerceWebsite.Controllers
{
	public class ProductController : Controller
	{
		private readonly IServiceManager _serviceManager;
		public ProductController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> AllProducts()
		{
			//var productDTOs = await _serviceManager.ProductService.GetAllAsync();
			/*List<AllProductsViewModel> allProducts = new List<AllProductsViewModel>();
			foreach (var p in productDTOs.ToList())
			{
				allProducts.Add(new AllProductsViewModel
				{
					name = p.name,
					price = p.price,
					description = p.description
				});
			}*/

			return View("AllProducts");
		}

		public IActionResult ProductDetails()
		{
			return View();
		}
	}
}
