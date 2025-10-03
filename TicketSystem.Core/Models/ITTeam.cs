using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Core.Models
{
    public class ITTeam
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public int DepartmentId = 2;

        public virtual ICollection<Ticket> Tickets { get; set; }
    }

  
}
