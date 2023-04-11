using hairSalonScheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class Stylist
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        public IEnumerable<StylistService> AvailableServices { get; set; }

        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public List<PromotionalPricing> PromotionalPricings { get; set; }

        public List<StylistHours> WorkingHours { get; set; }

        public List<Appointment> Appointments { get; set; } // To track appointments for the stylist
    }
}
