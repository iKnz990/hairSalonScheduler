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
    public class TheUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TheUsers
        public async Task<IActionResult> Index()
        {
              return View(await _context.Users.ToListAsync());
        }

        // GET: TheUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var theUser = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theUser == null)
            {
                return NotFound();
            }

            return View(theUser);
        }

        // GET: TheUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Email,PhoneNumber,DateOfBirth,PreferredPronouns,Allergies,PreferredStylistID,IsChecked")] TheUser theUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theUser);
        }

        // GET: TheUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var theUser = await _context.Users.FindAsync(id);
            if (theUser == null)
            {
                return NotFound();
            }
            return View(theUser);
        }

        // POST: TheUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Email,PhoneNumber,DateOfBirth,PreferredPronouns,Allergies,PreferredStylistID,IsChecked")] TheUser theUser)
        {
            if (id != theUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheUserExists(theUser.ID))
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
            return View(theUser);
        }

        // GET: TheUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var theUser = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (theUser == null)
            {
                return NotFound();
            }

            return View(theUser);
        }

        // POST: TheUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var theUser = await _context.Users.FindAsync(id);
            if (theUser != null)
            {
                _context.Users.Remove(theUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TheUserExists(int id)
        {
          return _context.Users.Any(e => e.ID == id);
        }
    }
}
