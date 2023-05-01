namespace SupportMVC.Models.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        //public int TicketId { get; set; }
        public int RequestorUserId { get; set; }
        public string Query { get; set; } = null!;
        public string AdditionalDetails { get; set; } = string.Empty;
        //public string QuerySolution { get; set; } = string.Empty;
        //public int TimeSpent { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public int? SMEUserId { get; set; }
        public int TechnologyId { get; set; }
        //public int StatusId { get; set; }
    }
}
