using System.Collections.Generic;
using System.Threading.Tasks;
using hairSalonScheduler.Enums;
using hairSalonScheduler.Interfaces;

public interface IHairSalonRepository : IUserRepository, IServiceRepository, IEmployeeServiceRepository, IEmployeeScheduleRepository, IAppointmentRepository
{
}
