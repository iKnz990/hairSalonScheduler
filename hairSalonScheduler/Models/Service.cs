using System.Collections.Generic;

namespace hairSalonScheduler.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }
        public List<int> StaffIds { get; set; }
    }
}
