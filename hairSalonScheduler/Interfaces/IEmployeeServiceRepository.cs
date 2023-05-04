using System.Collections.Generic;
using System.Threading.Tasks;
using hairSalonScheduler.Models;

public interface IEmployeeServiceRepository
{
    Task<IEnumerable<EmployeeService>> GetAllEmployeeServicesAsync();
    Task<EmployeeService> GetEmployeeServiceByIdAsync(int employeeServiceId);
    Task<IEnumerable<EmployeeService>> GetEmployeeServicesByEmployeeIdAsync(int employeeId);
    Task<IEnumerable<EmployeeService>> GetEmployeeServicesByServiceIdAsync(int serviceId);
    Task CreateEmployeeServiceAsync(EmployeeService employeeService);
    Task UpdateEmployeeServiceAsync(EmployeeService employeeService);
    Task DeleteEmployeeServiceAsync(int employeeServiceId);
}