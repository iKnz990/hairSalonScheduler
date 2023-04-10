using hairSalonScheduler.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Model
{
    public class StylistService
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Stylist")]
        public int StylistID { get; set; }

        [ForeignKey("Service")]
        public int ServiceID { get; set; }

        public virtual Stylist Stylist { get; set; }
        public virtual TheService Service { get; set; }

    }
}
