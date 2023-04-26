using hairSalonScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace hairSalonScheduler.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Users
        public async Task<IActionResult> Users()
        {
            return View("Users/Index", await _context.Users.ToListAsync());
        }
        // GET: Admin/Appointments
        public async Task<IActionResult> Appointments()
        {
            return View("Appointments/Index", await _context.Appointments.ToListAsync());
        }
        // Stylists
        public async Task<IActionResult> Stylists()
        {
            return View("Stylists/Index", await _context.Stylists.ToListAsync());
        }

        // PromotionalPricings
        public async Task<IActionResult> PromotionalPricings()
        {
            return View("PromotionalPricings/Index", await _context.PromotionalPricings.ToListAsync());
        }

        // SocialMediaAccounts
        public async Task<IActionResult> SocialMediaAccounts()
        {
            return View("SocialMediaAccounts/Index", await _context.SocialMediaAccount.ToListAsync());
        }

        // Services
        public async Task<IActionResult> Services()
        {
            return View("Services/Index", await _context.Services.ToListAsync());
        }

        // StylistHours
        public async Task<IActionResult> StylistHours()
        {
            return View("StylistHours/Index", await _context.StylistHours.ToListAsync());
        }

        // StylistServices
        public async Task<IActionResult> StylistServices()
        {
            return View("StylistServices/Index", await _context.StylistService.ToListAsync());
        }
    }
}
