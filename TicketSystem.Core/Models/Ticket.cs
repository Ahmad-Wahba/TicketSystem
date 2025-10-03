using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Core.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        public TicketStatus Status { get; set; }

        public TicketPriority Priority { get; set; }

        public int CreatedByUserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set;}
        public int? AssignedToUserId { get; set; }

        [ForeignKey(nameof(CreatedByUserId))]
        public User User { get; set; }

        [ForeignKey(nameof(AssignedToUserId))]
        public ITTeam Engineer { get; set; }

        public Comment Comment { get; set; }


    }


    public enum TicketStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }

    public enum TicketPriority
    {
        Low,
        Medium,
        High,
        Urgent
    }
}
