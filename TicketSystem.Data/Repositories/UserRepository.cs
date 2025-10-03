using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Models;

namespace TicketSystem.Data.Repositories
{
    public class UserRepository : GenericRepository<User> ,IUserRepository
    {
        private readonly ApplicationDbContext _context;


        public UserRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(D => D.Departments)
                .FirstOrDefaultAsync(U => U.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(D => D.Departments)
                .ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
