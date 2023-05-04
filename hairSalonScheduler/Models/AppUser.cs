using hairSalonScheduler.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace hairSalonScheduler.Models { 

public class AppUser
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public UserRole UserRole { get; set; }

    // Navigation properties
    public ICollection<TheAppointment> Appointments { get; set; }
    public ICollection<EmployeeService> EmployeeServices { get; set; }
    public ICollection<EmployeeSchedule> EmployeeSchedules { get; set; }
}
}