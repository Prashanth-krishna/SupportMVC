using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportMVC.Controllers
{
    [Route("mapping")]
    public class SMEMappingController : Controller
    {
        private readonly ISupportRepo _supportRepo;
        public SMEMappingController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var mapping = await _supportRepo.GetSMEMappings();
            return View(mapping);
        }
        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Users = new SelectList(await _supportRepo.GetSMEs(), "UserId", "UserName");
            ViewBag.Technology = new SelectList(await _supportRepo.GetTechnologiesAsync(), "TechnologyId", "TechnologyName");
            return View();
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(SMEMappingDTO smemapping)
        {
            var created = new SMEMapping { SMEMappingId = 0, UserId = smemapping.UserId, TechnologyId = smemapping.TechnologyId };
            await _supportRepo.PostSMEMapping(created);
            var result = await _supportRepo.SaveChangesAsync();
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
    }
}
