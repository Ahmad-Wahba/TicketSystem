using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Core.Models;

namespace TicketSystem.Data.Repositories
{
    public interface IITTeamRepository
    {
        Task<ITTeam?> GetByIdAsync(int id);
        Task<IEnumerable<ITTeam>> GetAllAsync();
        Task AddAsync(ITTeam team);
        Task UpdateAsync(ITTeam team);
        Task DeleteAsync(int id);
        Task<ITTeam?> GetByEmailAsync(string email);
    }
}
