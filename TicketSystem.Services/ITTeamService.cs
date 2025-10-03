using System;
using System.Collections.Generic;
using System.Linq;
using TicketSystem.Core.Interfaces;
using TicketSystem.Core.Models;
using TicketSystem.Data.Repositories;

namespace TicketSystem.Services
{
    public class ITTeamService : IITTeamService
    {
        private readonly IITTeamRepository _teamRepository; 

        public ITTeamService(IITTeamRepository teamRepository) 
        {
            _teamRepository = teamRepository;
        }

        public async Task<ITTeam?> GetByIdAsync(int id)
        {
            return await _teamRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ITTeam>> GetAllAsync()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task AddAsync(ITTeam team)
        {
            await _teamRepository.AddAsync(team);
        }

        public async Task UpdateAsync(ITTeam team)
        {
            await _teamRepository.UpdateAsync(team);
        }

        public async Task DeleteAsync(int id)
        {
            await _teamRepository.DeleteAsync(id);
        }

        public async Task<ITTeam?> GetByEmailAsync(string email)
        {
            return await _teamRepository.GetByEmailAsync(email);
        }
    }
}
