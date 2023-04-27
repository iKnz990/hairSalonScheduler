using System.Collections.Generic;
using hairSalonScheduler.Models;

public class StylistViewModel
{
    public Stylist Stylist { get; set; }
    public List<StylistAvailability> Availabilities { get; set; }

    public StylistViewModel()
    {
        Availabilities = new List<StylistAvailability>();
    }
}