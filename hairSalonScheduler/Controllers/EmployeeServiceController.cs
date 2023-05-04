using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hairSalonScheduler.Models;

[Route("api/[controller]")]
[ApiController]
public class EmployeeServiceController : ControllerBase
{
    private readonly IEmployeeServiceRepository _employeeServiceRepository;

    public EmployeeServiceController(IEmployeeServiceRepository employeeServiceRepository)
    {
        _employeeServiceRepository = employeeServiceRepository;
    }

    // GET: api/EmployeeService
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeService>>> GetEmployeeServices()
    {
        return Ok(await _employeeServiceRepository.GetAllEmployeeServicesAsync());
    }

    // GET: api/EmployeeService/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeService>> GetEmployeeService(int id)
    {
        var employeeService = await _employeeServiceRepository.GetEmployeeServiceByIdAsync(id);

        if (employeeService == null)
        {
            return NotFound();
        }

        return Ok(employeeService);
    }

    // GET: api/EmployeeService/employee/1
    [HttpGet("employee/{employeeId}")]
    public async Task<ActionResult<IEnumerable<EmployeeService>>> GetEmployeeServicesByEmployeeId(int employeeId)
    {
        return Ok(await _employeeServiceRepository.GetEmployeeServicesByEmployeeIdAsync(employeeId));
    }

    // GET: api/EmployeeService/service/1
    [HttpGet("service/{serviceId}")]
    public async Task<ActionResult<IEnumerable<EmployeeService>>> GetEmployeeServicesByServiceId(int serviceId)
    {
        return Ok(await _employeeServiceRepository.GetEmployeeServicesByServiceIdAsync(serviceId));
    }

    // POST: api/EmployeeService
    [HttpPost]
    public async Task<ActionResult<EmployeeService>> CreateEmployeeService(EmployeeService employeeService)
    {
        await _employeeServiceRepository.CreateEmployeeServiceAsync(employeeService);

        return CreatedAtAction(nameof(GetEmployeeService), new { id = employeeService.EmployeeServiceId }, employeeService);
    }

    // PUT: api/EmployeeService/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployeeService(int id, EmployeeService employeeService)
    {
        if (id != employeeService.EmployeeServiceId)
        {
            return BadRequest();
        }

        await _employeeServiceRepository.UpdateEmployeeServiceAsync(employeeService);

        return NoContent();
    }

    // DELETE: api/EmployeeService/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeService(int id)
    {
        var employeeService = await _employeeServiceRepository.GetEmployeeServiceByIdAsync(id);
        if (employeeService == null)
        {
            return NotFound();
        }

        await _employeeServiceRepository.DeleteEmployeeServiceAsync(id);

        return NoContent();
    }
}