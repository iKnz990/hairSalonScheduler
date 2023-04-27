using System;

namespace hairSalonScheduler.Models
{
    public class StylistAvailability
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; } = TimeSpan.Zero;
        public TimeSpan EndTime { get; set; } = TimeSpan.Zero;

        public int StylistId { get; set; }
        public Stylist Stylist { get; set; }
    }
}
