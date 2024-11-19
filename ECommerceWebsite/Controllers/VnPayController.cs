using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstractions;

namespace ECommerceWebsite.Controllers
{
	public class VnPayController : Controller
	{
		private readonly IServiceManager _serviceManager;
		public VnPayController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult CreatePaymentUrl()
		{
			string paymentUrl = _serviceManager.VnPayService.CreatePaymentUrl(HttpContext);

			return Redirect(paymentUrl);
		}
	}
}
