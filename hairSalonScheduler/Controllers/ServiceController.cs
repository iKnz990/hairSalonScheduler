using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hairSalonScheduler.Models;

[Route("api/[controller]")]
[ApiController]
public class ServiceController : ControllerBase
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceController(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    // GET: api/Service
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return Ok(await _serviceRepository.GetAllServicesAsync());
    }

    // GET: api/Service/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Service>> GetService(int id)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(id);

        if (service == null)
        {
            return NotFound();
        }

        return Ok(service);
    }

    // POST: api/Service
    [HttpPost]
    public async Task<ActionResult<Service>> CreateService(Service service)
    {
        await _serviceRepository.CreateServiceAsync(service);

        return CreatedAtAction(nameof(GetService), new { id = service.ServiceId }, service);
    }

    // PUT: api/Service/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateService(int id, Service service)
    {
        if (id != service.ServiceId)
        {
            return BadRequest();
        }

        await _serviceRepository.UpdateServiceAsync(service);

        return NoContent();
    }

    // DELETE: api/Service/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteService(int id)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(id);
        if (service == null)
        {
            return NotFound();
        }

        await _serviceRepository.DeleteServiceAsync(id);

        return NoContent();
    }
}