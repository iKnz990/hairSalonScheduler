using System.Collections.Generic;

namespace hairSalonScheduler.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public List<int> AppointmentIds { get; set; }
        public string Location { get; set; }
    }
}
