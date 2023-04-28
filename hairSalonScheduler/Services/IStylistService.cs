using hairSalonScheduler.Models;
using System.Collections.Generic;

namespace hairSalonScheduler.Services
{
    public interface IStylistService
    {
        IEnumerable<Service> GetServices();
        IEnumerable<Stylist> GetStylistsByService(int serviceId);
    }
}
