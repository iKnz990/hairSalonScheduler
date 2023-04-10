using hairSalonScheduler.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hairSalonScheduler.Models
{
    public class Stylist : TheUser
    {

        [Required(ErrorMessage = "Services offered are required.")]
        public IEnumerable<StylistService> AvailableServices { get; set; }

        public ICollection<SocialMediaAccount> SocialMediaAccounts { get; set; }

        public List<PromotionalPricing> PromotionalPricings { get; set; }

        public List<StylistHours> WorkingHours { get; set; }

    }
}
