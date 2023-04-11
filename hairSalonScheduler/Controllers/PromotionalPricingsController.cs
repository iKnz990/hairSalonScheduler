using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hairSalonScheduler.Models;

namespace hairSalonScheduler.Controllers
{
    public class PromotionalPricingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromotionalPricingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PromotionalPricings
        public async Task<IActionResult> Index()
        {
              return View(await _context.PromotionalPricings.ToListAsync());
        }

        // GET: PromotionalPricings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PromotionalPricings == null)
            {
                return NotFound();
            }

            var promotionalPricing = await _context.PromotionalPricings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (promotionalPricing == null)
            {
                return NotFound();
            }

            return View(promotionalPricing);
        }

        // GET: PromotionalPricings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PromotionalPricings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ServiceID,OriginalPrice,DiscountedPrice,StartDate,EndDate")] PromotionalPricing promotionalPricing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promotionalPricing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promotionalPricing);
        }

        // GET: PromotionalPricings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PromotionalPricings == null)
            {
                return NotFound();
            }

            var promotionalPricing = await _context.PromotionalPricings.FindAsync(id);
            if (promotionalPricing == null)
            {
                return NotFound();
            }
            return View(promotionalPricing);
        }

        // POST: PromotionalPricings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ServiceID,OriginalPrice,DiscountedPrice,StartDate,EndDate")] PromotionalPricing promotionalPricing)
        {
            if (id != promotionalPricing.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promotionalPricing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionalPricingExists(promotionalPricing.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(promotionalPricing);
        }

        // GET: PromotionalPricings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PromotionalPricings == null)
            {
                return NotFound();
            }

            var promotionalPricing = await _context.PromotionalPricings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (promotionalPricing == null)
            {
                return NotFound();
            }

            return View(promotionalPricing);
        }

        // POST: PromotionalPricings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PromotionalPricings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PromotionalPricings'  is null.");
            }
            var promotionalPricing = await _context.PromotionalPricings.FindAsync(id);
            if (promotionalPricing != null)
            {
                _context.PromotionalPricings.Remove(promotionalPricing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionalPricingExists(int id)
        {
          return _context.PromotionalPricings.Any(e => e.ID == id);
        }
    }
}
