using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ISupportRepo _supportRepo;

        public TicketController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await _supportRepo.GetTickets();
            return Ok(tickets);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _supportRepo.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(TicketDTO ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            Ticket createdTicket = new Ticket { TicketId = 0, RequestorUserId = ticket.RequestorUserId, Query = ticket.Query, AdditionalDetails = ticket.AdditionalDetails, CreatedAt = DateTime.Today, TechnologyId = ticket.TechnologyId, StatusId = 1 };
            await _supportRepo.PostTicket(createdTicket);
            await _supportRepo.SaveChangesAsync();
            return CreatedAtAction("GetTicket", new { id = createdTicket.TicketId }, createdTicket);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteTicket(int ticketId)
        {
            var ticket = await _supportRepo.GetTicket(ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            _supportRepo.DeleteTicket(ticket);
            await _supportRepo.SaveChangesAsync();
            return NoContent();
        }
    }
}
