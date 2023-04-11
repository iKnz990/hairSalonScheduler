using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hairSalonScheduler.Models;

namespace hairSalonScheduler.Controllers
{
    public class StylistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StylistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stylists/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Stylists/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("ID,Name,Email,PhoneNumber")] Stylist stylist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stylist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redirect to the home page after registration
            }
            return View(stylist);
        }

        private bool StylistExists(int id)
        {
            return _context.Stylists.Any(e => e.ID == id);
        }
    }
}
