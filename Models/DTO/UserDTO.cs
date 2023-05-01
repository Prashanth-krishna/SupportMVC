namespace SupportMVC.Models.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; } = null!;
        public string EnterpriseId { get; set; } = null!;
        public string EmailId { get; set; } = null!;

        //public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
