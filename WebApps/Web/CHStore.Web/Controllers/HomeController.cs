using Microsoft.AspNetCore.Mvc;

namespace CHStore.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
