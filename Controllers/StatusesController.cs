using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportMVC.Controllers
{
    [Route("status")]
    public class StatusesController : Controller
    {
        private readonly ISupportRepo _supportRepo;
        public StatusesController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var statuses = await _supportRepo.GetStatusesAsync();
            return View(statuses);
        }
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(StatusDTO status)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            var created = new Status { StatusId = 0, StatusName = status.StatusName };
            await _supportRepo.PostStatus(created);
            var result = await _supportRepo.SaveChangesAsync();
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var status = await _supportRepo.GetStatusAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, StatusDTO status)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            await _supportRepo.UpdateStatus(new Status { StatusId = id, StatusName = status.StatusName });
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _supportRepo.GetStatusAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }
        [HttpPost]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id, StatusDTO status)
        {
            _supportRepo.DeleteStatus(new Status { StatusId = id, StatusName = status.StatusName });
            var result = await _supportRepo.SaveChangesAsync();
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var status = await _supportRepo.GetStatusAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }
    }

}
