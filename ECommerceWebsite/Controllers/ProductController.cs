using ECommerceWebsite.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Services.Abstractions;
using Shared;
using System.Collections;
using System.Security.Claims;

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
			if (User.Identity.IsAuthenticated)
			{
				viewModel.cartViewModel = await getCart();
				viewModel.total = viewModel.cartViewModel.Sum(x => x.price * x.quantity);
			}
			return View("ProductList", viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> ProductDetails(ObjectId productId)
		{
			Console.WriteLine(productId);
			var product = await _serviceManager.ProductService.GetByIdAsync(productId);
			return View("ProductDetails", product.Adapt<ProductViewModel>());
		}
		
		private async Task<List<CartItemViewModel>> getCart()
		{
			var cart = await _serviceManager.CartService.GetByIdAsync(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
			List<CartItemViewModel> items = new List<CartItemViewModel>();
			foreach (var item in cart.items)
			{
				items.Add(new CartItemViewModel()
				{
					productId = item.productId,
					quantity = item.quantity,
					price = item.price
				});
			}
			return items;
		}
	}
}
