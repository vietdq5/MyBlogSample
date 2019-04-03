using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class UserRoleController : Controller
    {
        private IBusinessRoleService businessRoleService;
        private IUserRoleService userRoleService;
        private IUserService userService;
        private IRoleService roleService;

        public UserRoleController(IBusinessRoleService _businessRoleService
            , IUserRoleService _userRoleService
            , IUserService _userService
            , IRoleService _roleService)
        {
            businessRoleService = _businessRoleService;
            userRoleService = _userRoleService;
            userService = _userService;
            roleService = _roleService;
        }

        public IActionResult Index(int Id)
        {
            // get bussinessRole
            var businessRoles = businessRoleService.GetAll();
            var itemsBusinessRole = new List<SelectListItem>();
            foreach (var item in businessRoles)
            {
                itemsBusinessRole.Add(new SelectListItem() { Text = item.BusinessRoleName, Value = item.Id });
            }
            ViewBag.itemsBusinessRole = itemsBusinessRole;

            // get userId,UserName của user cần gán quyền
            var user = userService.FindById(Id);
            ViewBag.user = user;

            return View();
        }

        // get UserRole with businessID in Role and userId in UserRole
        public JsonResult getPermissions(string id, int usertemp)
        {
            // getall userrole from userd,bussinessRoleId
            var listuserRoles = userRoleService.userRoles(usertemp, id);
            // getall roles with BusinessRoleId
            var rolesWithBusinessId = roleService.GetRolesWithBusinessRoleId(id);
            //lay cac id permistion da dc gan cho nguoi dung
            var listpermissionID = listuserRoles.Select(p => p.RoleId);
            //so sanh va add them
            foreach (var item in rolesWithBusinessId)
            {
                if (!listpermissionID.Contains(item.RoleId))
                    listuserRoles.Add(item);
            }
            return Json(listuserRoles.OrderBy(x => x.Description));
        }

        public string updatePermission(int id, int usertemp)
        {
            string msg = "";
            var grant = userRoleService.FindById(usertemp, id);
            if (grant == null)
            {
                var userRole = new UserRoleViewModel() { UserId = usertemp, RoleId = id };
                userRoleService.Add(userRole);
                msg = "<div class='alert alert-success'>Cấp quyền thành công</div>";
            }
            else
            {
                userRoleService.Delete(grant);
                msg = "<div class='alert alert-success'>Hủy quyền thành công</div>";
            }
            userRoleService.Save();
            return msg;
        }
    }
}