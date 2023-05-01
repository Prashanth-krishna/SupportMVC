using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ISupportRepo _supportRepo;

        public RoleController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRolesAsync()
        {
            var roles = await _supportRepo.GetRolesAsync();
            return Ok(roles);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Role>> GetRoleAsync(int id)
        {
            var role = await _supportRepo.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(RoleDTO role)
        {
            if (role == null)
            {
                return BadRequest();
            }
            Role createdRole = new() { RoleId = 0, RoleName = role.RoleName };
            await _supportRepo.PostRole(createdRole);
            await _supportRepo.SaveChangesAsync();
            return CreatedAtAction("GetRoleAsync", new { id = createdRole.RoleId }, createdRole);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var role = await _supportRepo.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            _supportRepo.DeleteRole(role);
            await _supportRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
