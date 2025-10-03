using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Core.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }

}
