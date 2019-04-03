using Microsoft.AspNetCore.Mvc;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using SieuNhanGaoBlog.Areas.Admin.Data;

namespace SieuNhanGaoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AuthorizeBusiness))]
    public class RoleController : Controller
    {
        private IRoleService roleService;

        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }

        public IActionResult Index(string Id)
        {
            var roles = roleService.GetAllWithBusinessRole(Id);
            return View(roles);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int Id)
        {
            if (Id == 0)
            {
                return View();
            }
            var role = roleService.FindById(Id);
            if (role == null)
            {
                return View();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,RoleName,Description,BusinessRoleId")] RoleViewModel roleVM)
        {
            if (id != roleVM.Id)
            {
                return View();
            }

            if (ModelState.IsValid)
            {
                roleService.Update(roleVM);
                roleService.Save();
                return RedirectToAction("Index", new { Id = roleVM.BusinessRoleId });
            }
            return View();
        }
    }
}