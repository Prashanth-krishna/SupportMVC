using Microsoft.AspNetCore.Mvc;
using SupportMVC.Models;
using SupportMVC.Models.DTO;
using SupportMVC.Services;

namespace SupportMVC.Controllers
{
    [Route("roles")]
    public class RolesController : Controller
    {
        private readonly ISupportRepo _supportRepo;

        public RolesController(ISupportRepo supportRepo)
        {
            _supportRepo = supportRepo;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var roles = await _supportRepo.GetRolesAsync();
            return View(roles);


        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var role = await _supportRepo.GetRoleAsync(id);
            return View(role);
        }
        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> Edit(int id, RoleDTO role)
        {
            var getrole = await _supportRepo.GetRoleAsync(id);
            getrole.RoleName = role.RoleName;
            await _supportRepo.UpdateRole(getrole);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RoleDTO role)
        {
            var newRole = new Role { RoleId = 0, RoleName = role.RoleName };
            await _supportRepo.PostRole(newRole);
            await _supportRepo.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {

            var role = await _supportRepo.GetRoleAsync(id);
            return View(role);
        }
        [HttpPost]
        [ActionName("Delete")]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _supportRepo.GetRoleAsync(id);
            _supportRepo.DeleteRole(role);
            await _supportRepo.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
