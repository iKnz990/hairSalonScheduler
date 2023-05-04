using System;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class StylistAvailability
    {
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }

        [Range(typeof(TimeSpan), "00:00", "23:59")]
        public TimeSpan StartTime { get; set; } = TimeSpan.Zero;

        [Range(typeof(TimeSpan), "00:00", "23:59")]
        public TimeSpan EndTime { get; set; } = TimeSpan.Zero;

        public int StylistId { get; set; }
        public Stylist Stylist { get; set; }
    }

}
