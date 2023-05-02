using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models.DTO;
using SupportMVC.Models;
using SupportMVC.Services;

namespace SupportMVC.Controllers
{
    [Route("technology")]
    public class TechnologysController : Controller
    {
        private readonly ISupportRepo _supportRepo;

        public TechnologysController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var tech = await _supportRepo.GetTechnologiesAsync();
            return View(tech);


        }
        [HttpGet]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var tech = await _supportRepo.GetTechnologyAsync(id);
            return View(tech);
        }
        [HttpPost]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> Edit(int id, TechnologyDTO tech)
        {
            var gettech = await _supportRepo.GetTechnologyAsync(id);
            if (gettech == null)
            {
                return NotFound();
            }
            gettech.TechnologyName = tech.TechnologyName;
            await _supportRepo.UpdateTechnology(gettech);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(TechnologyDTO tech)
        {
            var newtech = new Technology { TechnologyId = 0, TechnologyName = tech.TechnologyName };
            await _supportRepo.PostTechnology(newtech);
            await _supportRepo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var tech = await _supportRepo.GetTechnologyAsync(id);
            return View(tech);
        }
        [HttpPost]
        [ActionName("Delete")]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Deletetech(int id)
        {
            var tech = await _supportRepo.GetTechnologyAsync(id);
            if (tech == null)
            {
                return NotFound();
            }
            _supportRepo.DeleteTechnology(tech);
            await _supportRepo.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}

