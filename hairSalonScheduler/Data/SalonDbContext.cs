using hairSalonScheduler.Models;
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
        modelBuilder.Entity<Service>()
            .Property(b => b.StaffIds)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

        modelBuilder.Entity<StylistAvailability>()
            .HasOne(sa => sa.Stylist)
            .WithMany(s => s.Availabilities)
            .HasForeignKey(sa => sa.StylistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
