using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hairSalonScheduler.Models
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Appointment date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Appointment time is required.")]
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        [Required(ErrorMessage = "Appointment type is required.")]
        [StringLength(100, ErrorMessage = "Appointment type cannot be longer than 100 characters.")]
        public string ApptType { get; set; }

        public string AdditionalInformation { get; set; }

        
        public List<TheService> Services { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        [ForeignKey("TheUser")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Stylist ID is required.")]
        [ForeignKey("Stylist")]
        public int StylistID { get; set; }

        public string CurrentHairPhotoPath { get; set; }
    }
}
