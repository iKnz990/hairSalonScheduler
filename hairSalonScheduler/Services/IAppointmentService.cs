using hairSalonScheduler.Models;
using System.Collections.Generic;

namespace hairSalonScheduler.Services
{
    public interface IAppointmentService
    {
        Appointment GetAppointment(int appointmentId);
        IEnumerable<Appointment> GetAllAppointments();
        void UpdateAppointment(Appointment appointment);
    }
}