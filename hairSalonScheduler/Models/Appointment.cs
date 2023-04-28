using System;

namespace hairSalonScheduler.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime SelectedDateTime { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }

        public int CustomerId { get; set; }
        public Customer Customers { get; set; }

        public int StylistId { get; set; }
        public Stylist Stylists { get; set; }

        public int ServiceId { get; set; }
        public Service Services { get; set; }
    }
}
