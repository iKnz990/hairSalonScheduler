using hairSalonScheduler.Models;
using System.Collections.Generic;
using System.Linq;

namespace hairSalonScheduler.Services
{
    public class StylistService : IStylistService
    {
        private readonly SalonDbContext _context;

        public StylistService(SalonDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Service> GetServices()
        {
            return _context.Services.ToList();
        }

        public IEnumerable<Stylist> GetStylistsByService(int serviceId)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == serviceId);
            if (service != null)
            {
                return _context.Stylists.Where(stylist => stylist.Id == service.StylistId);
            }

            return Enumerable.Empty<Stylist>();
        }
    }
}