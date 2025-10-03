using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Core.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int TicketId { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public virtual Ticket Ticket { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
