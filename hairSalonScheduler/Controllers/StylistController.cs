using hairSalonScheduler.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

public class StylistController : Controller
{
    private readonly SalonDbContext _context;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public StylistController(SalonDbContext context, IWebHostEnvironment hostingEnvironment)
    {
        _context = context;
        _hostingEnvironment = hostingEnvironment;
    }

    [HttpGet]
    public IActionResult AddStylist()
    {
        var stylist = new Stylist();
        stylist.Availabilities = new List<StylistAvailability>(); // initialize Availabilities property
        foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
        {
            stylist.Availabilities.Add(new StylistAvailability { DayOfWeek = dayOfWeek });
        }
        return View(stylist);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateStylist(Stylist stylist, IFormFile profileImage, List<string> availabilityStart, List<string> availabilityEnd)
    {
        if (ModelState.IsValid)
        {
            if (profileImage != null)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
                var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                // Create the images folder if it doesn't exist
                Directory.CreateDirectory(imagesFolder);

                var filePath = Path.Combine(imagesFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await profileImage.CopyToAsync(stream);
                }
                stylist.ProfileImage = "/images/" + uniqueFileName;
            }

            // Set the StartTime and EndTime for each availability
            stylist.Availabilities = new List<StylistAvailability>();
            for (int i = 0; i < availabilityStart.Count; i++)
            {
                TimeSpan.TryParse(availabilityStart[i], out TimeSpan startTime);
                TimeSpan.TryParse(availabilityEnd[i], out TimeSpan endTime);

                stylist.Availabilities.Add(new StylistAvailability
                {
                    DayOfWeek = (DayOfWeek)i,
                    StartTime = startTime,
                    EndTime = endTime
                });
            }

            _context.Add(stylist);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(GetStylist));
        }

        return View(stylist);
    }


    public IActionResult GetStylist()
    {
        List<Stylist> stylists = _context.Stylists
                                          .Include(s => s.Availabilities)
                                          .Include(s => s.Services)
                                          .ToList();

        return View(stylists);
    }


    public IActionResult UpdateStylist(int id, Stylist updatedStylist)
    {
        if (ModelState.IsValid)
        {
            Stylist stylist = _context.Stylists.FirstOrDefault(s => s.Id == id);
            if (stylist != null)
            {
                stylist.Gender = updatedStylist.Gender;
                stylist.ProfileImage = updatedStylist.ProfileImage;
                stylist.Availabilities = updatedStylist.Availabilities;
                stylist.Bio = updatedStylist.Bio;

                _context.SaveChanges();
                return RedirectToAction("GetStylist");
            }
        }

        return View(updatedStylist);
    }

    public IActionResult DeleteStylist(int id)
    {
        Stylist stylist = _context.Stylists.FirstOrDefault(s => s.Id == id);
        if (stylist != null)
        {
            _context.Stylists.Remove(stylist);
            _context.SaveChanges();
            return RedirectToAction("GetStylist");
        }

        return NotFound();
    }
}
