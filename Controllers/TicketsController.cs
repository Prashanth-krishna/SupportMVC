using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportMVC.Controllers
{
    [Route("tickets")]
    public class TicketsController : Controller
    {
        private readonly ISupportRepo _supportRepo;

        public TicketsController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tickets = await _supportRepo.GetTickets();
            return View(tickets);
        }
        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            var technologies = await _supportRepo.GetTechnologiesAsync();
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var username = await _supportRepo.GetUserByName(name);
            if (username == null)
            {
                var created = new Models.User { UserId = 0, UserName = name, EmailId = name, EnterpriseId = name, RoleId = 1 };
                await _supportRepo.PostUser(created);
                var result = await _supportRepo.SaveChangesAsync();
                if (!result)
                {
                    return View("Error");
                }
                else
                {
                    ViewBag.RequestorId = created.UserId;
                }
            }
            else
            {
                ViewBag.RequestorId = username.UserId;
            }

            ViewBag.Technology = technologies.Select(tech => new SelectListItem()
            {
                Text = tech.TechnologyName,
                Value = tech.TechnologyId.ToString()
            });

            return View();
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(TicketDTO ticket)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            await _supportRepo.PostTicket(new Models.Ticket
            {
                TicketId = 0,
                RequestorUserId = ticket.RequestorUserId,
                Query = ticket.Query,
                AdditionalDetails = ticket.AdditionalDetails,
                CreatedAt = DateTime.Now,
                TechnologyId = ticket.TechnologyId,
                StatusId = 1
            });
            var result = await _supportRepo.SaveChangesAsync();
            if (!result)
            {
                return View("Error");
            }
            var tickets = await _supportRepo.GetTickets();
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _supportRepo.GetTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewBag.StatusId = new SelectList(await _supportRepo.GetStatusesAsync(), "StatusId", "StatusName");
            ViewBag.TechnologyId = new SelectList(await _supportRepo.GetTechnologiesAsync(), "TechnologyId", "TechnologyName");
            ViewBag.SMEUserId = new SelectList(await _supportRepo.GetSMEwithTechnologyId(ticket.TechnologyId), "UserId", "UserName");
            return View(ticket);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(Ticket ticket)
        {
            if (ticket == null)
            {
                return NotFound();
            }
            await _supportRepo.UpdateTicket(ticket);
            var tickets = await _supportRepo.GetTickets();
            return RedirectToAction("Index");
        }
    }
}
