using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Status { get; set; }

        public List<int> AppointmentIds { get; set; }

        [StringLength(200)]
        public string Location { get; set; }
    }
}
