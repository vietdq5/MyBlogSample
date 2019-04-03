using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Utilities.Constaint;

namespace SieuNhanGaoBlog.Areas.Admin.Data
{
    public class AuthorizeBusiness : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private ISession _session => httpContextAccessor.HttpContext.Session;
        private ILoginService loginService;
        private IUserRoleService userRoleService;

        public AuthorizeBusiness(IHttpContextAccessor _httpContextAccessor
            , ILoginService _loginService
            , IUserRoleService _userRoleService
            )
        {
            httpContextAccessor = _httpContextAccessor;
            loginService = _loginService;
            userRoleService = _userRoleService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = _session.GetString(UserConstants.USER_ID);
            if (userId == null)
            {
                context.Result = new RedirectResult("Home/Index");
                return;
            }
            var parseUserId = int.Parse(userId);
            //lay ten action
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            string actionName = controllerActionDescriptor.ControllerName + "Controller-" + controllerActionDescriptor.ActionName;
            //lay thong tin user
            var user = loginService.IsAdmin(parseUserId);
            if (user != null)
            {
                return;
            }

            // get rolename of user
            var listRoles = userRoleService.UserRolesAuthorizes(parseUserId);
            if (!listRoles.Contains(actionName))
            {
                context.Result = new RedirectResult("Home/NotificationAuthorize");
                return;
            }
        }
    }
}