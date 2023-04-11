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
    public class StylistHoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StylistHoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StylistHours
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StylistHours.Include(s => s.Stylist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StylistHours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StylistHours == null)
            {
                return NotFound();
            }

            var stylistHours = await _context.StylistHours
                .Include(s => s.Stylist)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stylistHours == null)
            {
                return NotFound();
            }

            return View(stylistHours);
        }

        // GET: StylistHours/Create
        public IActionResult Create()
        {
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator");
            return View();
        }

        // POST: StylistHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StylistID,DayOfWeek,StartTime,EndTime")] StylistHours stylistHours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stylistHours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator", stylistHours.StylistID);
            return View(stylistHours);
        }

        // GET: StylistHours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StylistHours == null)
            {
                return NotFound();
            }

            var stylistHours = await _context.StylistHours.FindAsync(id);
            if (stylistHours == null)
            {
                return NotFound();
            }
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator", stylistHours.StylistID);
            return View(stylistHours);
        }

        // POST: StylistHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StylistID,DayOfWeek,StartTime,EndTime")] StylistHours stylistHours)
        {
            if (id != stylistHours.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stylistHours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StylistHoursExists(stylistHours.ID))
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
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator", stylistHours.StylistID);
            return View(stylistHours);
        }

        // GET: StylistHours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StylistHours == null)
            {
                return NotFound();
            }

            var stylistHours = await _context.StylistHours
                .Include(s => s.Stylist)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stylistHours == null)
            {
                return NotFound();
            }

            return View(stylistHours);
        }

        // POST: StylistHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StylistHours == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StylistHours'  is null.");
            }
            var stylistHours = await _context.StylistHours.FindAsync(id);
            if (stylistHours != null)
            {
                _context.StylistHours.Remove(stylistHours);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StylistHoursExists(int id)
        {
          return _context.StylistHours.Any(e => e.ID == id);
        }
    }
}
