using Microsoft.AspNetCore.Mvc;

namespace hairSalonScheduler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
