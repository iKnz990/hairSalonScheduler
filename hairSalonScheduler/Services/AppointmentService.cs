using hairSalonScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace hairSalonScheduler.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly SalonDbContext _dbContext;

        public AppointmentService(SalonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Appointment GetAppointment(int appointmentId)
        {
            return _dbContext.Appointments
                .Include(a => a.Customers)
                .Include(a => a.Services)
                .Include(a => a.Stylists)
                .FirstOrDefault(a => a.Id == appointmentId);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _dbContext.Appointments
                .Include(a => a.Customers)
                .Include(a => a.Services)
                .Include(a => a.Stylists)
                .ToList();
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _dbContext.Update(appointment);
            _dbContext.SaveChanges();
        }
    }
}
