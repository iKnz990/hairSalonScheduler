using System.Collections.Generic;
using System.Threading.Tasks;
using hairSalonScheduler.Models;
public interface IServiceRepository
{
    Task<IEnumerable<Service>> GetAllServicesAsync();
    Task<Service> GetServiceByIdAsync(int serviceId);
    Task CreateServiceAsync(Service service);
    Task UpdateServiceAsync(Service service);
    Task DeleteServiceAsync(int serviceId);
}