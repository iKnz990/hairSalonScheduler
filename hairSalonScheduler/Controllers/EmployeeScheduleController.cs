using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hairSalonScheduler.Models;

[Route("api/[controller]")]
[ApiController]
public class EmployeeScheduleController : ControllerBase
{
    private readonly IEmployeeScheduleRepository _employeeScheduleRepository;

    public EmployeeScheduleController(IEmployeeScheduleRepository employeeScheduleRepository)
    {
        _employeeScheduleRepository = employeeScheduleRepository;
    }

    // GET: api/EmployeeSchedule
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeSchedule>>> GetEmployeeSchedules()
    {
        return Ok(await _employeeScheduleRepository.GetAllEmployeeSchedulesAsync());
    }

    // GET: api/EmployeeSchedule/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EmployeeSchedule>> GetEmployeeSchedule(int id)
    {
        var employeeSchedule = await _employeeScheduleRepository.GetEmployeeScheduleByIdAsync(id);

        if (employeeSchedule == null)
        {
            return NotFound();
        }

        return Ok(employeeSchedule);
    }

    // GET: api/EmployeeSchedule/employee/1
    [HttpGet("employee/{employeeId}")]
    public async Task<ActionResult<IEnumerable<EmployeeSchedule>>> GetEmployeeSchedulesByEmployeeId(int employeeId)
    {
        return Ok(await _employeeScheduleRepository.GetEmployeeSchedulesByEmployeeIdAsync(employeeId));
    }

    // POST: api/EmployeeSchedule
    [HttpPost]
    public async Task<ActionResult<EmployeeSchedule>> CreateEmployeeSchedule(EmployeeSchedule employeeSchedule)
    {
        await _employeeScheduleRepository.CreateEmployeeScheduleAsync(employeeSchedule);

        return CreatedAtAction(nameof(GetEmployeeSchedule), new { id = employeeSchedule.EmployeeScheduleId }, employeeSchedule);
    }

    // PUT: api/EmployeeSchedule/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployeeSchedule(int id, EmployeeSchedule employeeSchedule)
    {
        if (id != employeeSchedule.EmployeeScheduleId)
        {
            return BadRequest();
        }

        await _employeeScheduleRepository.UpdateEmployeeScheduleAsync(employeeSchedule);

        return NoContent();
    }

    // DELETE: api/EmployeeSchedule/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeSchedule(int id)
    {
        var employeeSchedule = await _employeeScheduleRepository.GetEmployeeScheduleByIdAsync(id);
        if (employeeSchedule == null)
        {
            return NotFound();
        }

        await _employeeScheduleRepository.DeleteEmployeeScheduleAsync(id);

        return NoContent();
    }
}