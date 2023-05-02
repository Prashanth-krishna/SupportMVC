
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SupportMVC.Context;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportMVC.Services
{
    public class SupportRepo : ISupportRepo
    {
        private readonly SupportContext _context;
        public SupportRepo(SupportContext context)
        {
            _context = context;
        }

        public void DeleteMapping(SMEMapping smemapping)
        {
            _context.Remove(smemapping);
        }

        public void DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
        }

        public void DeleteStatus(Status status)
        {
            _context.Remove(status);
        }

        public void DeleteTechnology(Technology technology)
        {
            _context.Remove(technology);
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
        }

        public async Task<Role?> GetRoleAsync(int id)
        {
            return await _context.Roles.Where(r => r.RoleId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Role>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<SMEMapping?> GetSME(int smemappingid)
        {
            var sme = await _context.SMEMapping.Where(s => s.SMEMappingId == smemappingid).FirstOrDefaultAsync();
            if (sme == null)
            {
                return null;
            }
            return sme;
        }

        public async Task<IEnumerable<SMEMapping>> GetSMEMappings()
        {
            return await _context.SMEMapping
                .Include(s => s.User)
                .Include(s => s.Technology)
                .ToListAsync();
        }

        public async Task<IEnumerable<User>> GetSMEwithTechnologyId(int technologyId)
        {
            var smes = await _context.SMEMapping.Where(s => s.TechnologyId == technologyId)
                .Select(u=>u.UserId)
                .ToListAsync();
            return await _context.Users.Where(u => smes.Contains(u.UserId)).ToListAsync();
        }

        public async Task<Status?> GetStatusAsync(int id)
        {
            return await _context.Statuses.Where(s => s.StatusId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Status>> GetStatusesAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<IEnumerable<Technology>> GetTechnologiesAsync()
        {
            return await _context.Technologies.ToListAsync();
        }

        public async Task<Technology?> GetTechnologyAsync(int id)
        {
            return await _context.Technologies.Where(t => t.TechnologyId == id).FirstOrDefaultAsync();
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.Users
                .Where(u => u.UserId == id)
                .Include(r => r.Role)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users
                .Include(r => r.Role)
                .ToListAsync();
        }

        public async Task PostRole(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public async Task PostSMEMapping(SMEMapping smemapping)
        {
            await _context.SMEMapping.AddAsync(smemapping);
        }

        public async Task PostStatus(Status status)
        {
            await _context.Statuses.AddAsync(status);
        }

        public async Task PostTechnology(Technology technology)
        {
            await _context.Technologies.AddAsync(technology);

        }

        public async Task PostUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public void DeleteTicket(Ticket ticket)
        {
            _context.Remove(ticket);
        }

        public async Task<Ticket?> GetTicket(int id)
        {
            return await _context.Ticket.Where(t => t.TicketId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _context.Ticket
                .Include(t => t.Requestor)
                .Include(t => t.SME)
                .Include(t => t.Technology)
                .Include(t => t.Status)
                .ToListAsync();
        }

        public async Task PostTicket(Ticket ticket)
        {
            await _context.Ticket.AddAsync(ticket);
        }

        public async Task UpdateRole(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task UpdateTechnology(Technology tech)
        {
            _context.Entry(tech).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public async Task UpdateTicket(Ticket ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
            await SaveChangesAsync();
        }
        public async Task UpdateStatus(Status status)
        {
            _context.Entry(status).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<SMEMapping>> GetSMEsWithTechId(int techid)
        {
            return await _context.SMEMapping.Where(u => u.TechnologyId == techid)
                .ToListAsync();
        }
        public async Task<IEnumerable<User>> GetSMEs()
        {
            return await _context.Users.Where(u => u.RoleId >= 2).ToListAsync();
        }

        public async Task<User?> GetUserByName(string name)
        {
            return await _context.Users.Where(u => u.UserName == name).FirstOrDefaultAsync();
        }
    }
}
