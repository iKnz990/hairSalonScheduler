using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hairSalonScheduler.Models;

namespace hairSalonScheduler.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SalonDbContext _context;

        public CustomerController(SalonDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(customer);
        }
    }
}

