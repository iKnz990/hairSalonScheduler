using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using hairSalonScheduler.Models;



namespace hairSalonScheduler.Models
{
    public class EmployeeSchedule
    {
        [Key]
        public int EmployeeScheduleId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public DateTime EndDateTime { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        // Navigation properties
        public AppUser Employee { get; set; }
    }
}
