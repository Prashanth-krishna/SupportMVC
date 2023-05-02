using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMEController : ControllerBase
    {
        private readonly ISupportRepo _supportRepo;

        public SMEController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SMEMapping>>> GetSMEMapping()
        {
            var smes = await _supportRepo.GetSMEMappings();
            return Ok(smes);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<User?>> GetSMEwithTechnologyId(int id)
        {
            var user = await _supportRepo.GetSMEwithTechnologyId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<User?>> PostSME(SMEMappingDTO sMEMappingDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            SMEMapping sme = new() { SMEMappingId = 0, UserId = sMEMappingDTO.UserId, TechnologyId = sMEMappingDTO.TechnologyId };
            await _supportRepo.PostSMEMapping(sme);
            await _supportRepo.SaveChangesAsync();
            return CreatedAtAction("GetSME", new { id = sme.TechnologyId }, sme);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteSME(int id)
        {
            var sme = await _supportRepo.GetSME(id);
            if (sme == null)
            {
                return NotFound();
            }
            _supportRepo.DeleteMapping(new SMEMapping { SMEMappingId = id, UserId = sme.UserId, TechnologyId = sme.TechnologyId });
            await _supportRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
