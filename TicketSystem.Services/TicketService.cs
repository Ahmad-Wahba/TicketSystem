using AutoMapper;
using TicketSystem.Core.DTOs;
using TicketSystem.Core.Interfaces;
using TicketSystem.Core.Models;
using TicketSystem.Data.Repositories;

namespace TicketSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository , IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<TicketViewDto> CreateTicketAsync(TicketCreateDto ticketDto)
        {
            // 1. Map DTO to the database model
            var ticket = new Ticket
            {
                Title = ticketDto.Title,
                Description = ticketDto.Description,
                Priority = ticketDto.Priority,
                CreatedByUserId = ticketDto.CreatedByUserId,
                Status = TicketStatus.Open, // Default status
                CreatedAt = DateTime.UtcNow
            };

            // 2. Add to repository and save changes
            await _ticketRepository.AddAsync(ticket);

            // 3. Map the result back to a View DTO
            var ticketViewDto = new TicketViewDto
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status.ToString(),
                Priority = ticket.Priority.ToString(),
                CreatedAt = ticket.CreatedAt,
                CreatedByUserName = ticket?.User.FullName ?? "Unknown User"
            };

            return ticketViewDto;
        }


        public async Task<TicketViewDto> GetTicketByIdAsync(int id)
        {
            var ticket = await  _ticketRepository.GetTicketWithDetailsAsync(id);
            if (ticket == null) return null;
            return _mapper.Map<TicketViewDto>(ticket);
        }

        public async Task<IEnumerable<TicketViewDto>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllTicketsWithDetailsAsync();
            return _mapper.Map<IEnumerable<TicketViewDto>>(tickets);
        }

        public async Task<TicketUpdateDto> UpdateTicketAsync(int id, TicketUpdateDto ticketDto)
        {
            var ticket = await _ticketRepository.UpdateTicketAsync(id , ticketDto);
            if (ticket == null) return null;
            return _mapper.Map<TicketUpdateDto>(ticket);
        }

        public async void DeleteTicket(int id)
        {
           var ticket = await _ticketRepository.GetByIdAsync(id);
            _ticketRepository.Delete(ticket);
        }
    }
}