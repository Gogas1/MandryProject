using Microsoft.AspNetCore.Mvc;

namespace Mandry.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
