using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithIdentity.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
