using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using hairSalonScheduler.Enums;

namespace hairSalonScheduler.Models
{
    public class TheAppointment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public AppointmentStatus AppointmentStatus { get; set; }

        // Navigation properties
        public AppUser User { get; set; }
        public AppUser Employee { get; set; }
        public Service Service { get; set; }
    }
}