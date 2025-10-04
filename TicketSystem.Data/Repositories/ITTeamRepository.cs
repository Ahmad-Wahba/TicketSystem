using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Models;

namespace TicketSystem.Data.Repositories
{
    public class ITTeamRepository : IITTeamRepository
    {
        private readonly ApplicationDbContext _context;

        public ITTeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ITTeam?> GetByIdAsync(int id)
        {
            return await _context.ITTeams.FindAsync(id);
        }

        public async Task<IEnumerable<ITTeam>> GetAllAsync()
        {
            return await _context.ITTeams.ToListAsync();
        }

        public async Task AddAsync(ITTeam team)
        {
            await _context.ITTeams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ITTeam team)
        {
            _context.ITTeams.Update(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _context.ITTeams.FindAsync(id);
            if (team != null)
            {
                _context.ITTeams.Remove(team);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ITTeam?> GetByEmailAsync(string email)
        {
            return await _context.ITTeams.FirstOrDefaultAsync(u => u.Email == email);
        }
    }

}
