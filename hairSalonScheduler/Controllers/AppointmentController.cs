using System.Linq;
using hairSalonScheduler.Models;
using hairSalonScheduler.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace hairSalonScheduler.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IStylistService _stylistService;
        private readonly ICustomerService _customerService;
        private readonly SalonDbContext _dbContext;

        public AppointmentController(IStylistService stylistService, ICustomerService customerService, SalonDbContext dbContext)
        {
            _stylistService = stylistService;
            _customerService = customerService;
            _dbContext = dbContext;
        }

        //View the Appointment
        [HttpGet]
        public IActionResult GetAppointment()
        {
            var appointments = _dbContext.Appointments.Include(a => a.Customer).Include(a => a.Stylist).Include(a => a.Service).ToList();
            return View(appointments);
        }
        //Create the Appointment
        public IActionResult CreateAppointment()
        {
            ViewBag.Services = new SelectList(_dbContext.Services, "Id", "Category");
            ViewBag.Customers = new SelectList(_dbContext.Customers, "Id", "Name");
            ViewBag.Stylists = new SelectList(_dbContext.Stylists, "Id", "Name");
            return View();
        }


        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            var customer = _customerService.GetCustomer(appointment.CustomerId);
            var stylist = _stylistService.GetStylistsByService(appointment.StylistId).FirstOrDefault();

            if (customer == null || stylist == null)
            {
                return BadRequest("Invalid customer or stylist.");
            }

            appointment.Customer = customer;
            appointment.Stylist = stylist;

            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetAvailableStylists(int serviceId)
        {
            var stylists = _stylistService.GetStylistsByService(serviceId);
            return Json(stylists);
        }
    }
}
