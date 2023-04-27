namespace hairSalonScheduler.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ContactInformation { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
    }
}
