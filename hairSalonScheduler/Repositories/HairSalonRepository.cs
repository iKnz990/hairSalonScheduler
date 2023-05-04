using hairSalonScheduler.Enums;
using hairSalonScheduler.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hairSalonScheduler.Models;


public class HairSalonRepository { 
    private readonly SalonDbContext _dbContext;

    public HairSalonRepository(SalonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Implement IUserRepository methods
    public async Task AddUserAsync(AppUser user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<AppUser> GetUserByIdAsync(int userId)
    {
        return await _dbContext.Users.FindAsync(userId);
    }

    public async Task UpdateUserAsync(AppUser user)
    {
        _dbContext.Entry(user).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }


    // Implement IServiceRepository methods

    public async Task CreateServiceAsync(Service service)
    {
        _dbContext.Services.Add(service);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteServiceAsync(int serviceId)
    {
        var service = await _dbContext.Services.FindAsync(serviceId);
        if (service != null)
        {
            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Service>> GetAllServicesAsync()
    {
        return await _dbContext.Services.ToListAsync();
    }

    public async Task<Service> GetServiceByIdAsync(int serviceId)
    {
        return await _dbContext.Services.FindAsync(serviceId);
    }

    public async Task UpdateServiceAsync(Service service)
    {
        _dbContext.Entry(service).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    // Implement IEmployeeServiceRepository methods
    public async Task CreateEmployeeServiceAsync(EmployeeService employeeService)
    {
        _dbContext.EmployeeServices.Add(employeeService);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeServiceAsync(int employeeServiceId)
    {
        var employeeService = await _dbContext.EmployeeServices.FindAsync(employeeServiceId);
        if (employeeService != null)
        {
            _dbContext.EmployeeServices.Remove(employeeService);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<EmployeeService>> GetAllEmployeeServicesAsync()
    {
        return await _dbContext.EmployeeServices.ToListAsync();
    }

    public async Task<EmployeeService> GetEmployeeServiceByIdAsync(int employeeServiceId)
    {
        return await _dbContext.EmployeeServices.FindAsync(employeeServiceId);
    }

    public async Task<IEnumerable<EmployeeService>> GetEmployeeServicesByEmployeeIdAsync(int employeeId)
    {
        return await _dbContext.EmployeeServices
            .Where(e => e.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<IEnumerable<EmployeeService>> GetEmployeeServicesByServiceIdAsync(int serviceId)
    {
        return await _dbContext.EmployeeServices
            .Where(e => e.ServiceId == serviceId)
            .ToListAsync();
    }

    public async Task UpdateEmployeeServiceAsync(EmployeeService employeeService)
    {
        _dbContext.Entry(employeeService).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    // Implement IEmployeeScheduleRepository methods
    public async Task CreateEmployeeScheduleAsync(EmployeeSchedule employeeSchedule)
    {
        _dbContext.EmployeeSchedules.Add(employeeSchedule);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeScheduleAsync(int employeeScheduleId)
    {
        var employeeSchedule = await _dbContext.EmployeeSchedules.FindAsync(employeeScheduleId);
        if (employeeSchedule != null)
        {
            _dbContext.EmployeeSchedules.Remove(employeeSchedule);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<EmployeeSchedule>> GetAllEmployeeSchedulesAsync()
    {
        return await _dbContext.EmployeeSchedules.ToListAsync();
    }

    public async Task<EmployeeSchedule> GetEmployeeScheduleByIdAsync(int employeeScheduleId)
    {
        return await _dbContext.EmployeeSchedules.FindAsync(employeeScheduleId);
    }

    public async Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesByEmployeeIdAsync(int employeeId)
    {
        return await _dbContext.EmployeeSchedules
            .Where(e => e.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task UpdateEmployeeScheduleAsync(EmployeeSchedule employeeSchedule)
    {
        _dbContext.Entry(employeeSchedule).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<EmployeeSchedule> GetEmployeeScheduleByEmployeeIdAsync(int employeeId)
    {
        return await _dbContext.EmployeeSchedules
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }


    // Implement IAppointmentRepository methods
    public async Task CreateAppointmentAsync(TheAppointment appointment)
    {
        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAppointmentAsync(int appointmentId)
    {
        var appointment = await _dbContext.Appointments.FindAsync(appointmentId);
        if (appointment != null)
        {
            _dbContext.Appointments.Remove(appointment);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TheAppointment>> GetAllAppointmentsAsync()
    {
        return await _dbContext.Appointments.ToListAsync();
    }

    public async Task<TheAppointment> GetAppointmentByIdAsync(int appointmentId)
    {
        return await _dbContext.Appointments.FindAsync(appointmentId);
    }

    public async Task<IEnumerable<TheAppointment>> GetAppointmentsByEmployeeIdAsync(int employeeId)
    {
        return await _dbContext.Appointments
            .Where(a => a.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<IEnumerable<TheAppointment>> GetAppointmentsByServiceIdAsync(int serviceId)
    {
        return await _dbContext.Appointments
            .Where(a => a.ServiceId == serviceId)
            .ToListAsync();
    }

    public async Task<IEnumerable<TheAppointment>> GetAppointmentsByStatusAsync(AppointmentStatus status)
    {
        return await _dbContext.Appointments
            .Where(a => a.AppointmentStatus == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<TheAppointment>> GetAppointmentsByUserIdAsync(int userId)
    {
        return await _dbContext.Appointments
            .Where(a => a.UserId == userId)
            .ToListAsync();
    }

    public async Task UpdateAppointmentAsync(TheAppointment appointment)
    {
        _dbContext.Entry(appointment).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }


}