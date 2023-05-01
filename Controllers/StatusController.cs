using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ISupportRepo _supportRepo;

        public StatusController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            var statuses = await _supportRepo.GetStatusesAsync();
            return Ok(statuses);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Status>> GetStatusAsync(int id)
        {
            var status = await _supportRepo.GetStatusAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(StatusDTO status)
        {
            if (status == null)
            {
                return BadRequest();
            }
            Status createdStatus = new Status { StatusId = 0, StatusName = status.StatusName };
            await _supportRepo.PostStatus(createdStatus);
            await _supportRepo.SaveChangesAsync();

            return CreatedAtAction("GetStatus", new { id = createdStatus.StatusId }, createdStatus);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteStatus(int id)
        {
            var statusToDelete = await _supportRepo.GetStatusAsync(id);
            if (statusToDelete == null)
            {
                return NotFound();
            }
            _supportRepo.DeleteStatus(new Status { StatusId = id, StatusName = statusToDelete.StatusName });
            await _supportRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
