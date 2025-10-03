namespace TicketSystem.Core.DTOs
{
    public class TicketViewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserName { get; set; }
        public string? AssignedToITMemberName { get; set; }
    }
}
