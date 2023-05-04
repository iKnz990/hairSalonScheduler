using System.Collections.Generic;
using System.Threading.Tasks;
using hairSalonScheduler.Models;

public interface IEmployeeScheduleRepository
{
    Task<IEnumerable<EmployeeSchedule>> GetAllEmployeeSchedulesAsync();
    Task<EmployeeSchedule> GetEmployeeScheduleByIdAsync(int employeeScheduleId);
    Task<IEnumerable<EmployeeSchedule>> GetEmployeeSchedulesByEmployeeIdAsync(int employeeId);
    Task CreateEmployeeScheduleAsync(EmployeeSchedule employeeSchedule);
    Task UpdateEmployeeScheduleAsync(EmployeeSchedule employeeSchedule);
    Task DeleteEmployeeScheduleAsync(int employeeScheduleId);
    Task<EmployeeSchedule> GetEmployeeScheduleByEmployeeIdAsync(int employeeId);
}