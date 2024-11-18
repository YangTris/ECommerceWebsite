using Domain.Entities;
using ECommerceWebsite.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Services;
using Services.Abstractions;
using Shared;
using System.Security.Claims;

namespace ECommerceWebsite.Controllers
{
	public class OrderController : Controller
	{
		private readonly IServiceManager serviceManager;
		private UserManager<ApplicationUser> userManager;
		public OrderController(IServiceManager serviceManager, UserManager<ApplicationUser> userManager)
		{
			this.serviceManager = serviceManager;
			this.userManager = userManager;
		}
		public async Task<IActionResult> Index()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var itemList = await getCart();
			var viewmodel = new OrderViewModel();
			var user = await userManager.GetUserAsync(User);
			
			viewmodel.OrderDate = DateTime.Now.ToString("dd/MM/yyyy");
			viewmodel.userId = userId;
			viewmodel.name = user.UserName;
			viewmodel.phoneNumber = user.PhoneNumber;
			viewmodel.email = user.Email;
			viewmodel.address = "";
			viewmodel.items = itemList;
			viewmodel.total = itemList.Sum(x => x.price * x.quantity);
			viewmodel.cartViewModel = itemList;

			return View("Index",viewmodel);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var itemList = await getCart();
            var viewmodel = new OrderViewModel();
            var user = await userManager.GetUserAsync(User);

            viewmodel.OrderDate = DateTime.Now.ToString("dd/MM/yyyy");
            viewmodel.userId = userId;
            viewmodel.name = user.UserName;
            viewmodel.phoneNumber = user.PhoneNumber;
            viewmodel.email = user.Email;
            viewmodel.address = "";
            viewmodel.items = itemList;
            viewmodel.total = itemList.Sum(x => x.price * x.quantity);
            viewmodel.cartViewModel = itemList;

            return View(viewmodel);
        }

        [HttpPost]
		public async Task<IActionResult> Create(OrderViewModel vm)
        {
            var orderEntity = vm.Adapt<OrderDTO>();
            //await serviceManager.OrderService.CreateAsync(orderEntity);
            return RedirectToAction("History");
        }

		public async Task<IActionResult> History()
		{
			var order = await serviceManager.OrderService.GetByUserIdAsync(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
			var viewmodel = order.Adapt<OrderDetailViewModel>();
			return View(viewmodel);
		}

		private async Task<List<CartItemViewModel>> getCart()
		{
			var cart = await serviceManager.CartService.GetByIdAsync(ObjectId.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
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
