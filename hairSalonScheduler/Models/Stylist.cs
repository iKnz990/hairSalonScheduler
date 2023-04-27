using System.Collections.Generic;
using System;

namespace hairSalonScheduler.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string ProfileImage { get; set; }
        public string Bio { get; set; }

        public List<StylistAvailability> Availabilities { get; set; }
    }
}
