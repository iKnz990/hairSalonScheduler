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
    public class SocialMediaAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialMediaAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialMediaAccounts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SocialMediaAccount.Include(s => s.Stylist);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SocialMediaAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SocialMediaAccount == null)
            {
                return NotFound();
            }

            var socialMediaAccount = await _context.SocialMediaAccount
                .Include(s => s.Stylist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMediaAccount == null)
            {
                return NotFound();
            }

            return View(socialMediaAccount);
        }

        // GET: SocialMediaAccounts/Create
        public IActionResult Create()
        {
            ViewData["StylistId"] = new SelectList(_context.Stylists, "ID", "Discriminator");
            return View();
        }

        // POST: SocialMediaAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SocialMediaType,AccountId,StylistId")] SocialMediaAccount socialMediaAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialMediaAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StylistId"] = new SelectList(_context.Stylists, "ID", "Discriminator", socialMediaAccount.StylistId);
            return View(socialMediaAccount);
        }

        // GET: SocialMediaAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SocialMediaAccount == null)
            {
                return NotFound();
            }

            var socialMediaAccount = await _context.SocialMediaAccount.FindAsync(id);
            if (socialMediaAccount == null)
            {
                return NotFound();
            }
            ViewData["StylistId"] = new SelectList(_context.Stylists, "ID", "Discriminator", socialMediaAccount.StylistId);
            return View(socialMediaAccount);
        }

        // POST: SocialMediaAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SocialMediaType,AccountId,StylistId")] SocialMediaAccount socialMediaAccount)
        {
            if (id != socialMediaAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMediaAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaAccountExists(socialMediaAccount.Id))
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
            ViewData["StylistId"] = new SelectList(_context.Stylists, "ID", "Discriminator", socialMediaAccount.StylistId);
            return View(socialMediaAccount);
        }

        // GET: SocialMediaAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SocialMediaAccount == null)
            {
                return NotFound();
            }

            var socialMediaAccount = await _context.SocialMediaAccount
                .Include(s => s.Stylist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMediaAccount == null)
            {
                return NotFound();
            }

            return View(socialMediaAccount);
        }

        // POST: SocialMediaAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SocialMediaAccount == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SocialMediaAccount'  is null.");
            }
            var socialMediaAccount = await _context.SocialMediaAccount.FindAsync(id);
            if (socialMediaAccount != null)
            {
                _context.SocialMediaAccount.Remove(socialMediaAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaAccountExists(int id)
        {
          return _context.SocialMediaAccount.Any(e => e.Id == id);
        }
    }
}
