using TicketSystem.Core.DTOs;
using TicketSystem.Core.Interfaces;
using TicketSystem.Core.Models;

namespace TicketSystem.Data.Repositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<Ticket> GetTicketWithDetailsAsync(int id);
        Task<IEnumerable<Ticket>> GetAllTicketsWithDetailsAsync();
        Task<Ticket> UpdateTicketAsync(int id, TicketUpdateDto ticketDto);
    }
}
