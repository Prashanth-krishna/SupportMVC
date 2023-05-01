namespace SupportMVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string EnterpriseId { get; set; } = null!;
        public string EmailId { get; set; } = null!;

        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
