using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using hairSalonScheduler.Models;


namespace hairSalonScheduler.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal BasePrice { get; set; }

        // Navigation properties
        public ICollection<EmployeeService> EmployeeServices { get; set; }
        public ICollection<TheAppointment> Appointments { get; set; }
    }
}
