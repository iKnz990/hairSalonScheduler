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
using System.Text.Json.Serialization;
using System.Text.Json;

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

    [HttpGet]
    public IActionResult EditStylist(int id)
    {
        Stylist stylist = _context.Stylists
            .Include(s => s.Availabilities)
            .Include(s => s.Services)
            .FirstOrDefault(s => s.Id == id);

        if (stylist == null)
        {
            return NotFound();
        }

        // Add available services to the ViewBag
        ViewBag.Services = _context.Services.ToList();
        ViewData["Services"] = JsonSerializer.Serialize(_context.Services.ToList(), new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.Preserve });

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


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStylist(int id, Stylist updatedStylist, IFormFile newProfileImage, List<string> availabilityStart, List<string> availabilityEnd, List<int> Services, List<int> RemovedServices)
    {
        if (ModelState.IsValid)
        {
            _context.Entry(updatedStylist).State = EntityState.Detached;

            Stylist stylist = _context.Stylists.Include(s => s.Availabilities).FirstOrDefault(s => s.Id == id);
            if (stylist != null)
            {
                if (newProfileImage != null)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + newProfileImage.FileName;
                    var imagesFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    Directory.CreateDirectory(imagesFolder);

                    var filePath = Path.Combine(imagesFolder, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await newProfileImage.CopyToAsync(stream);
                    }
                    stylist.ProfileImage = "/images/" + uniqueFileName;
                }

                stylist.Name = updatedStylist.Name;
                stylist.Gender = updatedStylist.Gender;
                stylist.Bio = updatedStylist.Bio;
                stylist.Services = updatedStylist.Services;
                stylist.Availabilities = updatedStylist.Availabilities;
                //Availabilities
                for (int i = 0; i < availabilityStart.Count; i++)
                {
                    TimeSpan.TryParse(availabilityStart[i], out TimeSpan startTime);
                    TimeSpan.TryParse(availabilityEnd[i], out TimeSpan endTime);

                    var dayOfWeek = (DayOfWeek)i;
                    var availability = stylist.Availabilities.FirstOrDefault(a => a.DayOfWeek == dayOfWeek);
                    if (availability != null)
                    {
                        availability.StartTime = startTime;
                        availability.EndTime = endTime;
                    }
                    else
                    {
                        availability = new StylistAvailability
                        {
                            DayOfWeek = dayOfWeek,
                            StartTime = startTime,
                            EndTime = endTime,
                            StylistId = id
                        };
                        stylist.Availabilities.Add(availability);
                    }
                    _context.Entry(availability).State = EntityState.Modified;

                }

                // Services
                var currentServices = _context.Services.Where(s => s.StylistId == id).ToList();
                foreach (var serviceId in Services)
                {
                    var service = _context.Services.Find(serviceId);
                    if (service != null)
                    {
                        service.StylistId = id;
                    }
                }

                // Remove services
                if (RemovedServices != null)
                {
                    foreach (var removedServiceId in RemovedServices)
                    {
                        var removedService = _context.Services.Find(removedServiceId);
                        if (removedService != null)
                        {
                            stylist.Services.Remove(removedService);
                            _context.Services.Remove(removedService); // Add this line
                        }
                    }
                }
                _context.Update(stylist);
                _context.SaveChanges();
                return RedirectToAction("GetStylist");
            }
        }

        return View("EditStylist", updatedStylist);
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
