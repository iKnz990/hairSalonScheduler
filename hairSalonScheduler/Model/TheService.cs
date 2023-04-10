using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public enum ServiceType
    {
        Hair,
        Makeup,
        Nails,
        // Add more service types as needed
    }

    public class TheService
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Service name is required.")]
        [StringLength(100, ErrorMessage = "Service name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Service type is required.")]
        public ServiceType Type { get; set; }

        [Required(ErrorMessage = "Service cost is required.")]
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }

    }
}
