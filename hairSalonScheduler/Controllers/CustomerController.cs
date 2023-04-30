using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hairSalonScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        // Get Customer
        public async Task<IActionResult> GetCustomer()
        {
            var customers = await _context.Customers
                                          .Include(c => c.Appointments)
                                          .ThenInclude(a => a.Services)
                                          .Include(c => c.Appointments)
                                          .ThenInclude(a => a.Stylists)
                                          .ToListAsync();
            return View(customers);
        }
        // Update Customer
        [HttpGet]
        public async Task<IActionResult> EditCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomer(int id, Customer updatedCustomer)
        {
            if (id != updatedCustomer.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(updatedCustomer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Customers.Any(c => c.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(GetCustomer));
            }
            return View(updatedCustomer);
        }

        // Delete Customer
        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetCustomer");
        }
    }
}
    

