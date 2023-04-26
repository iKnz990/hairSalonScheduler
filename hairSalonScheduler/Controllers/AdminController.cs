using hairSalonScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using hairSalonScheduler.ViewModels;


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

        public IActionResult CreateStylist()
        {
            return View("Stylists/Create", new StylistCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStylist(StylistCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Stylist);
                await _context.SaveChangesAsync();

                foreach (var promo in viewModel.PromotionalPricings)
                {
                    promo.ServiceID = viewModel.Stylist.ID;
                    _context.Add(promo);
                }

                foreach (var service in viewModel.StylistServices)
                {
                    service.StylistID = viewModel.Stylist.ID;
                    _context.Add(service);
                }

                foreach (var account in viewModel.SocialMediaAccounts)
                {
                    account.StylistId = viewModel.Stylist.ID;
                    _context.Add(account);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Stylist));
            }

            return View("Stylists/Create", viewModel);
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
