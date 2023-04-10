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
    public class TheServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TheServices
        public async Task<IActionResult> Index()
        {
              return View(await _context.Services.ToListAsync());
        }

        // GET: TheServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var theService = await _context.Services
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theService == null)
            {
                return NotFound();
            }

            return View(theService);
        }

        // GET: TheServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Type,Cost")] TheService theService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theService);
        }

        // GET: TheServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var theService = await _context.Services.FindAsync(id);
            if (theService == null)
            {
                return NotFound();
            }
            return View(theService);
        }

        // POST: TheServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Type,Cost")] TheService theService)
        {
            if (id != theService.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheServiceExists(theService.ID))
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
            return View(theService);
        }

        // GET: TheServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var theService = await _context.Services
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theService == null)
            {
                return NotFound();
            }

            return View(theService);
        }

        // POST: TheServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Services == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Services'  is null.");
            }
            var theService = await _context.Services.FindAsync(id);
            if (theService != null)
            {
                _context.Services.Remove(theService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheServiceExists(int id)
        {
          return _context.Services.Any(e => e.ID == id);
        }
    }
}
