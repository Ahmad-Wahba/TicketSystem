using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
        public UserRole Role {get; set; }
        public string PasswordHash { get; set; }
        public int DepartmentId { get; set; }
        public String RemoteConnectionId { get; set; }


        [ForeignKey(nameof(DepartmentId))]
        public Department Departments { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }




    public enum UserRole
    {
        Employee, 
        Manager
    }
}
