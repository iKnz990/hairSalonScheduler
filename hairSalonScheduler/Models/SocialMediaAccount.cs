using hairSalonScheduler.Models;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class SocialMediaAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public SocialMediaType SocialMediaType { get; set; }

        [Required]
        public string AccountId { get; set; }

        public int StylistId { get; set; }
        public Stylist Stylist { get; set; }
    }
}
