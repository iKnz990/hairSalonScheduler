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
    public class StylistServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StylistServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StylistServices
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StylistService.Include(s => s.Service).Include(s => s.Stylist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StylistServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StylistService == null)
            {
                return NotFound();
            }

            var stylistService = await _context.StylistService
                .Include(s => s.Service)
                .Include(s => s.Stylist)
                .FirstOrDefaultAsync(m => m.StylistID == id);
            if (stylistService == null)
            {
                return NotFound();
            }

            return View(stylistService);
        }

        // GET: StylistServices/Create
        public IActionResult Create()
        {
            ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "Name");
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator");
            return View();
        }

        // POST: StylistServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,StylistID,ServiceID")] StylistService stylistService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stylistService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "Name", stylistService.ServiceID);
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator", stylistService.StylistID);
            return View(stylistService);
        }

        // GET: StylistServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StylistService == null)
            {
                return NotFound();
            }

            var stylistService = await _context.StylistService.FindAsync(id);
            if (stylistService == null)
            {
                return NotFound();
            }
            ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "Name", stylistService.ServiceID);
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator", stylistService.StylistID);
            return View(stylistService);
        }

        // POST: StylistServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,StylistID,ServiceID")] StylistService stylistService)
        {
            if (id != stylistService.StylistID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stylistService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StylistServiceExists(stylistService.StylistID))
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
            ViewData["ServiceID"] = new SelectList(_context.Services, "ID", "Name", stylistService.ServiceID);
            ViewData["StylistID"] = new SelectList(_context.Stylists, "ID", "Discriminator", stylistService.StylistID);
            return View(stylistService);
        }

        // GET: StylistServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StylistService == null)
            {
                return NotFound();
            }

            var stylistService = await _context.StylistService
                .Include(s => s.Service)
                .Include(s => s.Stylist)
                .FirstOrDefaultAsync(m => m.StylistID == id);
            if (stylistService == null)
            {
                return NotFound();
            }

            return View(stylistService);
        }

        // POST: StylistServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StylistService == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StylistService'  is null.");
            }
            var stylistService = await _context.StylistService.FindAsync(id);
            if (stylistService != null)
            {
                _context.StylistService.Remove(stylistService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StylistServiceExists(int id)
        {
          return _context.StylistService.Any(e => e.StylistID == id);
        }
    }
}
