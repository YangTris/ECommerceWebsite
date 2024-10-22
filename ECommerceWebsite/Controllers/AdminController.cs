using ECommerceWebsite.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace ECommerceWebsite.Controllers
{
	public class AdminController : Controller
	{
		private readonly IServiceManager _serviceManager;

		public AdminController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			var productList = await _serviceManager.ProductService.GetAllAsync();
			AdminProductViewModel viewModel = new AdminProductViewModel();
			viewModel._products = productList;
			return View("ProductList",viewModel);
		}
	}
}
