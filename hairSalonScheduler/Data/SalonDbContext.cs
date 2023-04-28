using hairSalonScheduler.Models;
using hairSalonScheduler.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class SalonDbContext : DbContext
{
    public SalonDbContext(DbContextOptions<SalonDbContext> options)
        : base(options)
    {
    }

    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<StylistAvailability> StylistAvailabilities { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StylistAvailability>()
            .HasOne(sa => sa.Stylist)
            .WithMany(s => s.Availabilities)
            .HasForeignKey(sa => sa.StylistId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Customer)
            .WithMany(c => c.Appointments)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Stylist)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.StylistId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Stylist>().HasData(
            new Stylist { Id = 1, 
                Name = "John Doe", 
                Gender = "Male", 
                ProfileImage = "https://via.placeholder.com/150", 
                Bio = "Experienced stylist with over 10 years in the industry" },
            new Stylist { 
                Id = 2, 
                Name = "Jane Doe", 
                Gender = "Female", 
                ProfileImage = "https://via.placeholder.com/150", 
                Bio = "Expert in cutting-edge styles and techniques" },
            new Stylist { 
                Id = 3, 
                Name = "Mark Smith", 
                Gender = "Male", 
                ProfileImage = "https://via.placeholder.com/150", 
                Bio = "Specializes in coloring and highlights" }
         );

        
        modelBuilder.Entity<Customer>().HasData(
            new Customer { 
                Id = 1, 
                Name = "Alice Smith", 
                Email = "alice@gmail.com", 
                Password = "password123", 
                DateOfBirth = new DateTime(1990, 1, 1), 
                Gender = Gender.Female, 
                Address = "123 Main St, Anytown USA", 
                LoyaltyPoints = 100 },
            new Customer { 
                Id = 2, 
                Name = "Bob Johnson", 
                Email = "bob@gmail.com", 
                Password = "password123", 
                DateOfBirth = new DateTime(1985, 6, 15), 
                Gender = Gender.Male, 
                Address = "456 High St, Anytown USA", 
                LoyaltyPoints = 50 },
            new Customer { 
                Id = 3, 
                Name = "Charlie Brown", 
                Email = "charlie@gmail.com", 
                Password = "password123", 
                DateOfBirth = new DateTime(1995, 12, 25), 
                Gender = Gender.Other, 
                Address = "789 Maple Ave, Anytown USA", 
                LoyaltyPoints = 200 }
        );

        modelBuilder.Entity<Appointment>().HasData(
           new Appointment { 
               Id = 1, 
               SelectedDateTime = new DateTime(2023, 05, 01, 9, 0, 0), 
               Status = "Scheduled", 
               PaymentStatus = "Unpaid", 
               CustomerId = 1, 
               StylistId = 1, 
               ServiceId = 1 },
           new Appointment { 
               Id = 2, 
               SelectedDateTime = new DateTime(2023, 05, 02, 10, 0, 0), 
               Status = "Scheduled", 
               PaymentStatus = "Unpaid", 
               CustomerId = 2, 
               StylistId = 2, 
               ServiceId = 2 },
           new Appointment { 
               Id = 3, 
               SelectedDateTime = new DateTime(2023, 05, 03, 11, 0, 0), 
               Status = "Scheduled", 
               PaymentStatus = "Unpaid", 
               CustomerId = 3, 
               StylistId = 3, 
               ServiceId = 3 }
        );

        modelBuilder.Entity<Service>().HasData(
            new Service
            {
                Id = 1,
                Category = "Haircut",
                Availability = "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16",
                Price = 50.00m,
                StylistId = 1
            },
            new Service
            {
                Id = 2,
                Category = "Haircut",
                Availability = "Mon:9-17,Tue:9-17,Wed:9-17,Thu:9-17,Fri:9-17,Sat:9-15",
                Price = 45.00m,
                StylistId = 2
            },
            new Service
            {
                Id = 3,
                Category = "Haircut",
                Availability = "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16",
                Price = 55.00m,
                StylistId = 3
            },

            new Service
            {
                Id = 5,
                Category = "Coloring",
                Availability = "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16",
                Price = 120.00m,
                StylistId = 1
            },
            new Service
            {
                Id = 6,
                Category = "Coloring",
                Availability = "Mon:9-17,Tue:9-17,Wed:9-17,Thu:9-17,Fri:9-17,Sat:9-15",
                Price = 130.00m,
                StylistId = 2
            },
            new Service
            {
                Id = 7,
                Category = "Coloring",
                Availability = "Mon:10-18,Tue:10-18,Wed:10-18,Thu:10-18,Fri:10-18,Sat:10-16",
                Price = 110.00m,
                StylistId = 3
            }

        );

    }
}
