using hairSalonScheduler.Models;
using System.Collections.Generic;

namespace hairSalonScheduler.ViewModels
{
    public class StylistCreateViewModel
    {
        public Stylist Stylist { get; set; }
        public List<PromotionalPricing> PromotionalPricings { get; set; }
        public List<StylistService> StylistServices { get; set; }
        public List<SocialMediaAccount> SocialMediaAccounts { get; set; }
    }
}
