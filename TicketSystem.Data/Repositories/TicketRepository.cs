using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.DTOs;
using TicketSystem.Core.Models;
namespace TicketSystem.Data.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Ticket> GetTicketWithDetailsAsync(int id)
        {
            return await _context.Tickets
                .Include(t => t.User)
                .Include(t => t.Engineer)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsWithDetailsAsync()
        {
            return await _context.Tickets
                .Include(t => t.User)
                .Include(t => t.Engineer)
                .ToListAsync();
        }


        public async Task<Ticket> UpdateTicketAsync(int id, TicketUpdateDto ticketDto)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return null; // Not found
            }
            ticket.Title = ticketDto.Title;
            ticket.Description = ticketDto.Description;
            ticket.Priority = ticketDto.Priority;
            ticket.Status = ticketDto.Status;
            ticket.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return ticket;
        }
    }
}
