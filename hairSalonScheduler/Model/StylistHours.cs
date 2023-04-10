using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hairSalonScheduler.Models
{
    public class StylistHours
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Stylist ID is required.")]
        [ForeignKey("Stylist")]
        public int StylistID { get; set; }

        [Required(ErrorMessage = "Day of week is required.")]
        public int DayOfWeek { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        public virtual Stylist Stylist { get; set; }
    }
}
