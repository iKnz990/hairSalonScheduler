using hairSalonScheduler.Enums;
using hairSalonScheduler.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hairSalonScheduler.Models;


public interface IAppointmentRepository
{
    Task<IEnumerable<TheAppointment>> GetAllAppointmentsAsync();
    Task<TheAppointment> GetAppointmentByIdAsync(int appointmentId);
    Task<IEnumerable<TheAppointment>> GetAppointmentsByUserIdAsync(int userId);
    Task<IEnumerable<TheAppointment>> GetAppointmentsByEmployeeIdAsync(int employeeId);
    Task<IEnumerable<TheAppointment>> GetAppointmentsByServiceIdAsync(int serviceId);
    Task<IEnumerable<TheAppointment>> GetAppointmentsByStatusAsync(AppointmentStatus status);
    Task CreateAppointmentAsync(TheAppointment appointment);
    Task UpdateAppointmentAsync(TheAppointment appointment);
    Task DeleteAppointmentAsync(int appointmentId);
}