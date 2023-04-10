using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hairSalonScheduler.Models
{
    public class PromotionalPricing
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Service ID is required.")]
        [ForeignKey("TheService")]
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Original price is required.")]
        [DataType(DataType.Currency)]
        public decimal OriginalPrice { get; set; }

        [Required(ErrorMessage = "Discounted price is required.")]
        [DataType(DataType.Currency)]
        public decimal DiscountedPrice { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}