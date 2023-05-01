using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ISupportRepo _supportRepo;

        public TechnologyController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        //[Route("GetAllTechnologies")]
        public async Task<ActionResult<IEnumerable<Technology>>> GetAllTechnologies()
        {
            var technologies = await _supportRepo.GetTechnologiesAsync();
            return Ok(technologies);
        }
        [HttpGet]
        [Route("{id:int}")]
        //[Route("GetTechnology")]
        public async Task<ActionResult<Technology>> GetTechnology(int id)
        {
            var technology = await _supportRepo.GetTechnologyAsync(id);
            if (technology == null)
            {
                return NotFound();
            }
            return Ok(technology);
        }
        [HttpPost]
        public async Task<ActionResult<Technology>> PostTechnology(TechnologyDTO technology)
        {
            if (technology == null)
            {
                return BadRequest();
            }
            Technology createdTechnology = new Technology { TechnologyId = 0, TechnologyName = technology.TechnologyName };
            await _supportRepo.PostTechnology(createdTechnology);
            await _supportRepo.SaveChangesAsync();
            return CreatedAtAction("GetTechnology", new { id = createdTechnology.TechnologyId }, createdTechnology);

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteTechnology(int id)
        {
            var technologyToDelete = await _supportRepo.GetTechnologyAsync(id);
            if (technologyToDelete == null)
            {
                return NotFound();
            }
            _supportRepo.DeleteTechnology(new Technology { TechnologyId = technologyToDelete.TechnologyId, TechnologyName = technologyToDelete.TechnologyName });
            await _supportRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
