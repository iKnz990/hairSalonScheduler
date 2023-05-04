using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class Stylist
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(20)]
        public string Gender { get; set; }

        [StringLength(1000)]
        public string ProfileImage { get; set; }

        [ StringLength(1000)]
        public string Bio { get; set; }

        public List<StylistAvailability> Availabilities { get; set; }
        public List<Service> Services { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
