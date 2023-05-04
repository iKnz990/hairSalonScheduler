using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using hairSalonScheduler.Models;
using hairSalonScheduler.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hairSalonScheduler.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IStylistService _stylistService;
        private readonly ICustomerService _customerService;
        private readonly SalonDbContext _dbContext;

        public AppointmentController(IStylistService stylistService, ICustomerService customerService, IAppointmentService appointmentService, SalonDbContext dbContext)
        {
            _appointmentService = appointmentService;
            _stylistService = stylistService;
            _customerService = customerService;
            _dbContext = dbContext;
        }

        //Read the Appointments
        [HttpGet]
        public IActionResult GetAppointment()
        {
            var appointments = _dbContext.Appointments.Include(a => a.Customers).Include(a => a.Stylists).Include(a => a.Services).ToList();
            return View(appointments);
        }

        //Create the Appointment
        public IActionResult CreateAppointment()
        {
            ViewBag.Customers = new SelectList(_dbContext.Customers, "Id", "Name");
            ViewBag.Stylists = new SelectList(_dbContext.Stylists, "Id", "Name");
            ViewBag.ServicesWithPricesAndStylists = _dbContext.Services.Include(s => s.Stylist).ToList();

            var serviceList = _dbContext.Services.Include(s => s.Stylist).Select(s => new SelectListItem
            {
                Value = $"{s.Id},{s.StylistId}",
                Text = $"{s.Category} by: {s.Stylist.Name} -- {s.Price.ToString("C")}"
            }).ToList();

            ViewBag.Services = new SelectList(serviceList, "Value", "Text");

            return View();
        }


        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            var customer = _customerService.GetCustomer(appointment.CustomerId);
            var stylist = _stylistService.GetStylistsByService(appointment.ServiceId)
                .FirstOrDefault(s => s.Id == appointment.StylistId);

            if (customer == null || stylist == null)
            {
                return BadRequest("Invalid customer or stylist.");
            }

            appointment.Customers = customer;

            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();

            return RedirectToAction("GetAppointment");
        }

        //Edit the Appointments
        [HttpGet]
        public async Task<IActionResult> EditAppointment(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _dbContext.Appointments
                    .Include(a => a.Customers)
                    .Include(a => a.Services)
                    .Include(a => a.Stylists)
                    .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            var serviceList = _dbContext.Services.Include(s => s.Stylist).Select(s => new SelectListItem
            {
                Value = $"{s.Id},{s.StylistId}",
                Text = $"{s.Category} by: {s.Stylist.Name} -- {s.Price.ToString("C")}"
            }).ToList();

            ViewBag.Services = new SelectList(serviceList, "Value", "Text", $"{appointment.ServiceId},{appointment.StylistId}");
            ViewBag.Customers = new SelectList(_dbContext.Customers, "Id", "Name", appointment.CustomerId);
            ViewBag.Stylists = new SelectList(_dbContext.Stylists, "Id", "Name", appointment.StylistId);

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,SelectedDateTime,Status,PaymentStatus,CustomerId,StylistId,ServiceId")] Appointment updatedAppointment)
        {

            if (ModelState.IsValid)
            {
                Appointment appointment = await _dbContext.Appointments.FindAsync(id);

                if (updatedAppointment == null)
                {
                    return NotFound();
                }

                appointment.SelectedDateTime = updatedAppointment.SelectedDateTime;
                appointment.Status = updatedAppointment.Status;
                appointment.PaymentStatus = updatedAppointment.PaymentStatus;
                appointment.StylistId = updatedAppointment.StylistId;
                appointment.ServiceId = updatedAppointment.ServiceId;

                try
                {
                    _dbContext.Update(appointment);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("GetAppointment");
            }

            var services = _dbContext.Services.Where(s => s.StylistId == updatedAppointment.StylistId).ToList();

            ViewData["Services"] = new SelectList(services, "Id", "Category", updatedAppointment.ServiceId);
            ViewData["Customers"] = new SelectList(_dbContext.Customers.ToList(), "Id", "Name", updatedAppointment.CustomerId);
            ViewData["Stylists"] = new SelectList(_dbContext.Stylists.ToList(), "Id", "Name", updatedAppointment.StylistId);

            return View(updatedAppointment);
        }

        private bool AppointmentExists(int id)
        {
            return _dbContext.Appointments.Any(a => a.Id == id);
        }
        [HttpGet]
        public IActionResult GetServicesByStylistId(int stylistId)
        {
            var services = _dbContext.Services.Where(s => s.StylistId == stylistId).ToList();

            return Json(services);
        }
        //Delete the Appointments
        public IActionResult DeleteAppointment(int id)
        {
            Appointment appointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                _dbContext.Appointments.Remove(appointment);
                _dbContext.SaveChanges();
                return RedirectToAction("GetAppointment");
            }

            return NotFound();
        }

    }
}
