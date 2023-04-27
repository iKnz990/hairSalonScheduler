using System;
using System.Collections.Generic;
using hairSalonScheduler.Models;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class StylistViewModel
{
    public Stylist Stylist { get; set; }
    public List<StylistAvailability> Availabilities { get; set; }

    public StylistViewModel()
    {
        Availabilities = new List<StylistAvailability>();
    }
}
