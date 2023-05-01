namespace SupportMVC.Models
{
    public class SMEMapping
    {
        public int SMEMappingId { get; set; }
        public User User { get; set; } = null!;
        public int UserId { get; set; }
        public Technology Technology { get; set; } = null!;
        public int TechnologyId { get; set; }

    }
}
