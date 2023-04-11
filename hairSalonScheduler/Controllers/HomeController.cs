using Microsoft.AspNetCore.Mvc;

namespace hairSalonScheduler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointments()
        {
            return RedirectToAction("Index", "Appointments");
        }

        public IActionResult PromotionalPricings()
        {
            return RedirectToAction("Index", "PromotionalPricings");
        }

        public IActionResult SocialMediaAccounts()
        {
            return RedirectToAction("Index", "SocialMediaAccounts");
        }

        public IActionResult Stylists()
        {
            return RedirectToAction("Index", "Stylists");
        }

        public IActionResult StylistHours()
        {
            return RedirectToAction("Index", "StylistHours");
        }

        public IActionResult StylistServices()
        {
            return RedirectToAction("Index", "StylistServices");
        }

        public IActionResult Services()
        {
            return RedirectToAction("Index", "TheServices");
        }

        public IActionResult Users()
        {
            return RedirectToAction("Index", "TheUsers");
        }

        public IActionResult RegisterStylist()
        {
            return RedirectToAction("Register", "Stylists");
        }
    }

}