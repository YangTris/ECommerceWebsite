using Domain.Entities;
using ECommerceWebsite.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;

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
		[HttpGet]
		public IActionResult ProductAdd()
		{
			Console.WriteLine("get productAdd");
			return View("ProductAdd");
		}

		[HttpPost]
		public async Task<IActionResult> ProductAdd(ProductViewModel product)
		{
			var entity = new ProductDTO(
				product.name,
				product.description,
				product.category,
				product.price,
				"product.imageUrl",
				product.timestamp
			);
			//Console.WriteLine(product.imageUrl.ToString());
			await _serviceManager.ProductService.CreateAsync(entity);
			return RedirectToAction("ProductList","Admin");
		}

        [HttpGet]
        public IActionResult ProductEdit()
        {
            Console.WriteLine("get productedit");
            return View("ProductEdit");
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductViewModel product)
		{
            var entity = new ProductDTO(
				product.name,
                product.description,
				product.category,
                product.price,
                "product.imageUrl",
                product.timestamp
            );
            //Console.WriteLine(product.imageUrl.ToString());
            await _serviceManager.ProductService.CreateAsync(entity);
            return RedirectToAction("ProductEdit", "Admin");
        }

		[HttpPost]
		public IActionResult ProductDelete()
		{
			Console.WriteLine("get productAdd");
			return View("ProductAdd");
		}
	}
}
