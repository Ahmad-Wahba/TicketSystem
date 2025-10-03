using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Core.DTOs;
using TicketSystem.Core.Interfaces;

namespace TicketSystem.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreateDto ticketDto)
        {

            var createdTicket = await _ticketService.CreateTicketAsync(ticketDto);

            return CreatedAtAction(nameof(GetTicketById), new { id = createdTicket.Id }, createdTicket);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            if (tickets == null || !tickets.Any())
                return NotFound();
            return Ok(tickets);

        }
    }
}
