using TicketSystem.Core.Interfaces;
using TicketSystem.Core.Models;

namespace TicketSystem.Data.Repositories
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetByEmailAsync(string email);

    }
}
