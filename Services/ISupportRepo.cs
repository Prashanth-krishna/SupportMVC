using SupportMVC.Models;

namespace SupportMVC.Services
{
    public interface ISupportRepo
    {
        Task<IEnumerable<Technology>> GetTechnologiesAsync();
        Task<Technology?> GetTechnologyAsync(int id);
        Task PostTechnology(Technology technology);
        Task UpdateTechnology(Technology technology);
        void DeleteTechnology(Technology technology);
        Task<bool> SaveChangesAsync();


        Task<IEnumerable<Status>> GetStatusesAsync();
        Task<Status?> GetStatusAsync(int id);
        Task PostStatus(Status status);
        Task UpdateStatus(Status status);
        void DeleteStatus(Status status);

        Task<IEnumerable<Role>> GetRolesAsync();
        Task<Role?> GetRoleAsync(int id);
        Task PostRole(Role role);
        Task UpdateRole(Role role);
        void DeleteRole(Role role);

        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUserByName(string name);
        Task<User?> GetUser(int id);

        Task PostUser(User user);
        void DeleteUser(User user);

        Task<IEnumerable<SMEMapping>> GetSMEMappings();
        Task<IEnumerable<User>> GetSMEwithTechnologyId(int technologyId);
        Task<SMEMapping?> GetSME(int smemappingid);
        
        Task<IEnumerable<User>> GetSMEs();
        Task PostSMEMapping(SMEMapping smemapping);
        void DeleteMapping(SMEMapping smemapping);

        Task<IEnumerable<Ticket>> GetTickets();
        Task<Ticket?> GetTicket(int id);
        Task PostTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
    }
}
