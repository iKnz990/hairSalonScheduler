using System.Collections.Generic;

namespace hairSalonScheduler.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Availability { get; set; }
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
