using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISupportRepo _supportRepo;

        public UserController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var user = await _supportRepo.GetUsers();
            return Ok(user);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _supportRepo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            User createdUser = new User { UserId = 0, UserName = userDTO.UserName, EnterpriseId = userDTO.EnterpriseId, EmailId = userDTO.EmailId, RoleId = userDTO.RoleId };
            await _supportRepo.PostUser(createdUser);
            await _supportRepo.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = createdUser.UserId }, createdUser);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var userToDelete = await _supportRepo.GetUser(id);
            if (userToDelete == null)
            {
                return NotFound();
            }
            _supportRepo.DeleteUser(new User { UserId = userToDelete.UserId, UserName = userToDelete.UserName, EnterpriseId = userToDelete.EnterpriseId, EmailId = userToDelete.EmailId, RoleId = userToDelete.RoleId, Role = userToDelete.Role });
            await _supportRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
