using hairSalonScheduler.Models;

namespace hairSalonScheduler.Services
{
    public interface ICustomerService
    {
        Customer GetCustomer(int customerId);
    }
}
