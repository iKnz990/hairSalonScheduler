using hairSalonScheduler.Model;
using hairSalonScheduler.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
    {
    }

    public DbSet<TheUser> Users { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<TheService> Services { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<PromotionalPricing> PromotionalPricings { get; set; }
    public DbSet<StylistHours> StylistHours { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StylistService>()
            .HasKey(ss => new { ss.StylistID, ss.ServiceID });

        modelBuilder.Entity<StylistService>()
            .HasOne(ss => ss.Stylist)
            .WithMany(s => s.AvailableServices)
            .HasForeignKey(ss => ss.StylistID);

        modelBuilder.Entity<StylistService>()
            .HasOne(ss => ss.Service)
            .WithMany()
            .HasForeignKey(ss => ss.ServiceID);
    }
}
