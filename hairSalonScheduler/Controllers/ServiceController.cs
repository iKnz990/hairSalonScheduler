using hairSalonScheduler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ServiceController : Controller
{
    private readonly SalonDbContext _context;

    public ServiceController(SalonDbContext context)
    {
        _context = context;
    }


    // GET: Services/Create
    public ActionResult Create()
    {
        var stylists = _context.Stylists.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name
        }).ToList();

        ViewBag.StylistList = stylists; // Change this line

        var viewModel = new CreateServiceViewModel();
        return View("AddService", viewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(CreateServiceViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            foreach (var stylistId in viewModel.StylistIds)
            {
                var service = new Service
                {
                    Category = viewModel.Category,
                    Availability = viewModel.Availability,
                    Price = viewModel.Price,
                    StylistId = stylistId
                };

                _context.Services.Add(service);
            }
            _context.SaveChanges();
            return RedirectToAction("GetService", "Service");
        }

        return View("AddService", viewModel);
    }

    public IActionResult GetService()
    {
        var services = _context.Services.Include(s => s.Stylist).ToList();
        return View("GetService", services);
    }

    [HttpGet]
    public IActionResult EditService(int id)
    {
        var service = _context.Services.Include(s => s.Stylist).FirstOrDefault(s => s.Id == id);
        if (service == null)
        {
            return NotFound();
        }

        return View("EditService", service);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult EditService([Bind("Id, Category, StylistId, Price")] Service service)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(service);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Services.Any(e => e.Id == service.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("GetService", "Service");
        }
        return View("EditService", service);
    }

}