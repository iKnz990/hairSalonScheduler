using hairSalonScheduler.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hairSalonScheduler.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SharedNavigationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IEmployeeServiceRepository _employeeServiceRepository;
        private readonly IEmployeeScheduleRepository _employeeScheduleRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public SharedNavigationController(IUserRepository userRepository, IServiceRepository serviceRepository,
            IEmployeeServiceRepository employeeServiceRepository, IEmployeeScheduleRepository employeeScheduleRepository,
            IAppointmentRepository appointmentRepository)
        {
            _userRepository = userRepository;
            _serviceRepository = serviceRepository;
            _employeeServiceRepository = employeeServiceRepository;
            _employeeScheduleRepository = employeeScheduleRepository;
            _appointmentRepository = appointmentRepository;
        }

        // Add action methods here using _userRepository, _serviceRepository, _employeeServiceRepository, _employeeScheduleRepository, and _appointmentRepository
    }
}