using System;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime SelectedDateTime { get; set; }

        [Required, StringLength(100)]
        public string Status { get; set; }

        [Required, StringLength(100)]
        public string PaymentStatus { get; set; }

        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        public int StylistId { get; set; }
        public Stylist Stylists { get; set; }

        public int ServiceId { get; set; }
        public Service Services { get; set; }
    }
}
