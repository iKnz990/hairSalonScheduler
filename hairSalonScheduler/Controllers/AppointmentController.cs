
using hairSalonScheduler.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hairSalonScheduler.Models;

namespace hairSalonScheduler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IEmployeeScheduleRepository _employeeScheduleRepository;

            public AppointmentController(IAppointmentRepository appointmentRepository, IEmployeeScheduleRepository employeeScheduleRepository)
            {
                _appointmentRepository = appointmentRepository;
                _employeeScheduleRepository = employeeScheduleRepository;
            }

            // GET: api/Appointment
            [HttpGet]
             public async Task<ActionResult<IEnumerable<TheAppointment>>> GetAppointments()
        {
            var appointments = await _appointmentRepository.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

            // GET: api/Appointment/5
            [HttpGet("{id}")]
            public async Task<ActionResult<TheAppointment>> GetAppointment(int id)
            {
                var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);

                if (appointment == null)
                {
                    return NotFound("Appointment not found");
                }

                return Ok(appointment);
            }

            // PUT: api/Appointment/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateAppointment(int id, TheAppointment appointment)
            {
                if (id != appointment.Id)
                {
                    return BadRequest("Appointment ID mismatch");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    await _appointmentRepository.UpdateAppointmentAsync(appointment);
                }
                catch (Exception ex)
                {
                    // Handle specific exceptions as needed
                    return StatusCode(500, $"An error occurred while updating the appointment: {ex.Message}");
                }

                return NoContent();
            }

            // POST: api/Appointment
            [HttpPost]
            public async Task<ActionResult<TheAppointment>> CreateAppointment(TheAppointment appointment)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                try
                {
                    await _appointmentRepository.CreateAppointmentAsync(appointment);
                }
                catch (Exception ex)
                {
                    // Handle specific exceptions as needed
                    return StatusCode(500, $"An error occurred while creating the appointment: {ex.Message}");
                }

                return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
            }

            // DELETE: api/Appointment/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteAppointment(int id)
            {
                try
                {
                    await _appointmentRepository.DeleteAppointmentAsync(id);
                }
                catch (Exception ex)
                {
                    // Handle specific exceptions as needed
                    return StatusCode(500, $"An error occurred while deleting the appointment: {ex.Message}");
                }

                return NoContent();
            }

            // GET: api/Appointment/IsStylistAvailable/5
            [HttpGet("IsStylistAvailable/{id}")]
            public async Task<ActionResult<bool>> IsStylistAvailable(int id, DateTime appointmentDate, TimeSpan duration)
            {
                var appointments = await _appointmentRepository.GetAppointmentsByEmployeeIdAsync(id);
                var employeeSchedule = await _employeeScheduleRepository.GetEmployeeScheduleByEmployeeIdAsync(id);

                if (employeeSchedule == null)
                {
                    return NotFound("Employee schedule not found");
                }

                var appointmentStartTime = appointmentDate;
                var appointmentEndTime = appointmentDate.Add(duration);

                if (appointmentStartTime < employeeSchedule.StartDateTime || appointmentEndTime > employeeSchedule.EndDateTime)
                {
                    return Ok(false);
                }

                if (!employeeSchedule.IsAvailable)
                {
                    return Ok(false);
                }

                var isStylistAvailable = !appointments.Any(a =>
                    a.AppointmentDate <= appointmentEndTime &&
                    a.AppointmentDate.Add(a.Service.Duration) >= appointmentStartTime);

                return Ok(isStylistAvailable);
            }

            // GET: api/Appointment/ByEmployeeId/5
            [HttpGet("ByEmployeeId/{id}")]
            public async Task<ActionResult<IEnumerable<TheAppointment>>> GetAppointmentsByEmployeeId(int id)
            {
                var appointments = await _appointmentRepository.GetAppointmentsByEmployeeIdAsync(id);
                return Ok(appointments);
            }

            // GET: api/Appointment/ByServiceId/5
            [HttpGet("ByServiceId/{id}")]
            public async Task<ActionResult<IEnumerable<TheAppointment>>> GetAppointmentsByServiceId(int id)
            {
                var appointments = await _appointmentRepository.GetAppointmentsByServiceIdAsync(id);
                return Ok(appointments);
            }

            // GET: api/Appointment/ByStatus/5
            [HttpGet("ByStatus/{status}")]
            public async Task<ActionResult<IEnumerable<TheAppointment>>> GetAppointmentsByStatus(AppointmentStatus status)
            {
                var appointments = await _appointmentRepository.GetAppointmentsByStatusAsync(status);
                return Ok(appointments);
            }

            // GET: api/Appointment/ByUserId/5
            [HttpGet("ByUserId/{id}")]
            public async Task<ActionResult<IEnumerable<TheAppointment>>> GetAppointmentsByUserId(int id)
            {
                var appointments = await _appointmentRepository.GetAppointmentsByUserIdAsync(id);
                return Ok(appointments);
            }
    }
}
    