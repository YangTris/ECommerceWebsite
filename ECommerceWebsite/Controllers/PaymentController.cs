using Microsoft.AspNetCore.Mvc;

namespace ECommerceWebsite.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult PaymentSuccess()
        {
            return View();
        }
    }
}
