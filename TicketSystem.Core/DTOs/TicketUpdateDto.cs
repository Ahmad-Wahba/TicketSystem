using System.ComponentModel.DataAnnotations;
using TicketSystem.Core.Models;

namespace TicketSystem.Core.DTOs
{
    public class TicketUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public TicketPriority Priority { get; set; }

        public TicketStatus Status { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
