using hairSalonScheduler.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using hairSalonScheduler.Models;

public class SalonDbContext : DbContext
{
    public SalonDbContext(DbContextOptions<SalonDbContext> options)
        : base(options)
    {
    }
    public DbSet<AppUser> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<EmployeeService> EmployeeServices { get; set; }
    public DbSet<TheAppointment> Appointments { get; set; }
    public DbSet<EmployeeSchedule> EmployeeSchedules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>().HasData(
            new AppUser { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "555-1234", Password = "password", UserRole = UserRole.User },
            new AppUser { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", PhoneNumber = "555-5678", Password = "password", UserRole = UserRole.Employee }
        );

        modelBuilder.Entity<Service>().HasData(
            new Service { ServiceId = 1, ServiceName = "Haircut", Duration = TimeSpan.FromMinutes(30), BasePrice = 25.00m },
            new Service { ServiceId = 2, ServiceName = "Shampoo", Duration = TimeSpan.FromMinutes(15), BasePrice = 10.00m },
            new Service { ServiceId = 3, ServiceName = "Coloring", Duration = TimeSpan.FromMinutes(60), BasePrice = 50.00m }
        );

        modelBuilder.Entity<EmployeeService>().HasData(
            new EmployeeService { EmployeeServiceId = 1, EmployeeId = 2, ServiceId = 1 },
            new EmployeeService { EmployeeServiceId = 2, EmployeeId = 2, ServiceId = 2 },
            new EmployeeService { EmployeeServiceId = 3, EmployeeId = 2, ServiceId = 3 }
        );

        modelBuilder.Entity<EmployeeSchedule>().HasData(
            new EmployeeSchedule { EmployeeScheduleId = 1, EmployeeId = 2, StartDateTime = DateTime.Now.Date.AddHours(9), EndDateTime = DateTime.Now.Date.AddHours(17), IsAvailable = true }
        );

        modelBuilder.Entity<TheAppointment>().HasData(
            new TheAppointment { Id = 1, UserId = 1, EmployeeId = 2, ServiceId = 1, AppointmentDate = DateTime.Now.Date.AddHours(10), AppointmentStatus = AppointmentStatus.Scheduled }
        );
    }
}