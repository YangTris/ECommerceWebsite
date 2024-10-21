using ECommerceWebsite.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
		public async Task<IActionResult> ProductList()
		{
			var productList = await _serviceManager.ProductService.GetAllAsync();
			IEnumerable<ProductViewModel> allProducts = productList.Adapt<IEnumerable<ProductViewModel>>();
			return View("ProductList", allProducts);
		}

		[HttpGet]
		public async Task<IActionResult> ProductDetails(ObjectId productId)
		{
			var product = await _serviceManager.ProductService.GetByIdAsync(productId);
			return View("ProductDetails",product.Adapt<ProductViewModel>());
		}
		[HttpGet]
		public IActionResult ProductAdd()
		{
			return View("ProductAdd");
		}

		[HttpPost]
		public IActionResult ProductAdd(ProductViewModel product)
		{
			return View("ProductDetails");
		}
	}
}
