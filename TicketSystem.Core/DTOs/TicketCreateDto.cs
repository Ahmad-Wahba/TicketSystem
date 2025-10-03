using System.ComponentModel.DataAnnotations;
using TicketSystem.Core.Models;

namespace TicketSystem.Core.DTOs
{
    public class TicketCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public TicketPriority Priority { get; set; }

        [Required]
        public int CreatedByUserId { get; set; }
    }
}
