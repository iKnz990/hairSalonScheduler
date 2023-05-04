using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hairSalonScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace hairSalonScheduler.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SalonDbContext _dbContext;

        public CustomerController(SalonDbContext context)
        {
            _dbContext = context;
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
                _dbContext.Add(customer);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(customer);
        }

        // Get Customer
        public async Task<IActionResult> GetCustomer()
        {
            var customers = await _dbContext.Customers
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
            var customer = await _dbContext.Customers.FindAsync(id);
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
                    _dbContext.Update(updatedCustomer);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dbContext.Customers.Any(c => c.Id == id)) return NotFound();
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
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetCustomer");
        }
    }
}
    

