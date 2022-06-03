using Microsoft.AspNetCore.Mvc;

namespace AuthorizationWithIdentity.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
