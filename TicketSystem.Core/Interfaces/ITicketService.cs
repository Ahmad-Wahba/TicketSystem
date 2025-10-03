using TicketSystem.Core.DTOs;

namespace TicketSystem.Core.Interfaces
{
    public interface ITicketService
    {
        Task<TicketViewDto> GetTicketByIdAsync(int id);
        Task<IEnumerable<TicketViewDto>> GetAllTicketsAsync();
        Task<TicketViewDto> CreateTicketAsync(TicketCreateDto ticketDto);
        Task<TicketUpdateDto> UpdateTicketAsync(int id, TicketUpdateDto ticketDto);
        void DeleteTicket(int id);
    }
}
