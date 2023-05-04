using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Category { get; set; }

        public string Availability { get; set; }

        [Required, Range(0, 10000)]
        public decimal Price { get; set; }


        public string DisplayName
        {
            get
            {
                return $"{Category} - {Price:C}";
            }
        }

        public int StylistId { get; set; }
        public virtual Stylist Stylist { get; set; }
    }
}
