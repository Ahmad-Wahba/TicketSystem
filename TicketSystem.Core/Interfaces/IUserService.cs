using TicketSystem.Core.DTOs;
using TicketSystem.Core.Models;

namespace TicketSystem.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserViewDto> CreateUser(UserCreateDto userCreateDto);
        Task<UserViewDto> GetUserById(int id);
        Task<IEnumerable<UserViewDto>> GetAllUsers();
        Task<bool> DeleteUser(int id);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
