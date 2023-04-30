using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hairSalonScheduler.Models
{
    public class CreateServiceViewModel
    {
        public string Category { get; set; }
        public string Availability { get; set; }
        public decimal Price { get; set; }
        public int StylistId { get; set; }

        public List<SelectListItem> Stylists { get; set; }
        public List<int> StylistIds { get; set; }
        public List<SelectListItem> Availabilities { get; set; } = new List<SelectListItem>();


    }
}