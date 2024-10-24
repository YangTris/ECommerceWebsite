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
			AllProductsViewModel viewModel = new AllProductsViewModel();
			viewModel.products = productList;
			viewModel.countProduct = productList.Count();
			return View("ProductList", viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> ProductDetails(ObjectId productId)
		{
			Console.WriteLine(productId);
			var product = await _serviceManager.ProductService.GetByIdAsync(productId);
			return View("ProductDetails", product.Adapt<ProductViewModel>());
		}
		
	}
}
