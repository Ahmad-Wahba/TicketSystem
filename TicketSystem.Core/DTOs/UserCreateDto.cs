using System.ComponentModel.DataAnnotations;
using TicketSystem.Core.Models;

namespace TicketSystem.Core.DTOs
{
    public class UserCreateDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } // We will hash this in the service
        public UserRole Role { get; set; }
        [Required]
        public int DepartmentName { get; set; }

        public String? RemoteConnectionId { get; set; }
    }
}