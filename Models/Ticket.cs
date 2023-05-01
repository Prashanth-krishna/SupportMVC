namespace SupportMVC.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public User Requestor { get; set; } = null!;
        public int RequestorUserId { get; set; }
        public string Query { get; set; } = null!;
        public string AdditionalDetails { get; set; } = string.Empty;
        public string QuerySolution { get; set; } = string.Empty;
        public int? TimeSpent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public User? SME { get; set; }
        public int? SMEUserId { get; set; }
        public Technology Technology { get; set; } = null!;
        public int TechnologyId {get;set;}
        public Status Status { get; set; } = null!;
        public int StatusId { get; set; }
        
    }
}
