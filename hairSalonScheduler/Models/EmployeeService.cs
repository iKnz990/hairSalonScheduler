using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using hairSalonScheduler.Models;


namespace hairSalonScheduler.Models
{
    public class EmployeeService
    {
        [Key]
        public int EmployeeServiceId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        [ForeignKey("Service")]
        public int ServiceId { get; set; }

        [DataType(DataType.Currency)]
        public decimal? CustomPrice { get; set; }

        // Navigation properties
        public AppUser Employee { get; set; }
        public Service Service { get; set; }
    }
}
