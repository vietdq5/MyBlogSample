using Microsoft.AspNetCore.Mvc;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using SieuNhanGaoBlog.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SieuNhanGaoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AuthorizeBusiness))]
    public class BusinessRoleController : Controller
    {
        private IBusinessRoleService businessRoleService;
        private IRoleService roleService;

        public BusinessRoleController(IBusinessRoleService _businessRoleService
                                      , IRoleService _roleService)
        {
            businessRoleService = _businessRoleService;
            roleService = _roleService;
        }

        public IActionResult Index()
        {
            var businessRoles = businessRoleService.GetAll();
            return View(businessRoles);
        }

        // get: udpate roles to database
        public IActionResult UpdateRole()
        {
            // get controlers,action flow namespace
            IList<Type> controllers = ReflectionControler.GetControllers("SieuNhanGaoBlog.Areas.Admin.Controllers");
            // get businessRoleId in table BusinessRole
            IList<string> controlersOlds = businessRoleService.GetAll().Select(s => s.Id).ToList();
            // get Roles in table Role
            IList<string> rolesOlds = roleService.GetAll().Select(s => s.RoleName).ToList();

            // iterator listCOntroller and check it contain in role name, execute  add businessRole
            foreach (var itemController in controllers)
            {
                if (!controlersOlds.Contains(itemController.Name))
                {
                    var businessRoleVm = new BusinessRoleViewModel { Id = itemController.Name, BusinessRoleName = "chua co mo ta" };
                    businessRoleService.Add(businessRoleVm);
                }
                // get actions flow controllers
                IList<string> actions = ReflectionControler.GetActions(itemController);
                foreach (var itemRoles in actions)
                {
                    if (!rolesOlds.Contains(itemController.Name + "-" + itemRoles))
                    {
                        var rolevm = new RoleViewModel { RoleName = itemController.Name + "-" + itemRoles, BusinessRoleId = itemController.Name };
                        roleService.Add(rolevm);
                    }
                }
            }
            businessRoleService.Save();
            roleService.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET: BusinessRoles/Edit/5
        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var businessRoleVM = businessRoleService.FindById(id);
            if (businessRoleVM == null)
            {
                return View();
            }
            return View(businessRoleVM);
        }

        // POST: BusinessRoles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,BusinessRoleName")] BusinessRoleViewModel businessRoleViewModel)
        {
            if (id != businessRoleViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                businessRoleService.Update(businessRoleViewModel);
                businessRoleService.Save();

                return RedirectToAction(nameof(Index));
            }
            return View(businessRoleViewModel);
        }

        // GET: BusinessRoles/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessRole = businessRoleService.FindById(id);
            if (businessRole == null)
            {
                return NotFound();
            }

            return View(businessRole);
        }

        // POST: BusinessRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            businessRoleService.Delete(id);
            businessRoleService.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}