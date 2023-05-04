using System.Collections.Generic;
using System.Threading.Tasks;
using hairSalonScheduler.Models;


namespace hairSalonScheduler.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<AppUser> GetUserByIdAsync(int userId);
        Task<AppUser> GetUserByEmailAsync(string email);
        Task AddUserAsync(AppUser user);
        Task UpdateUserAsync(AppUser user);
        Task DeleteUserAsync(int userId);
    }
}
