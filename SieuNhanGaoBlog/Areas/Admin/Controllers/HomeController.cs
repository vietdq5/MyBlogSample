using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Utilities.Constaint;
using SieuNhanGao.Utilities.Helpers;
using SieuNhanGaoBlog.Areas.Admin.Models;

namespace SieuNhanGaoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private ILoginService loginService;

        public HomeController(ILoginService _loginService)
        {
            loginService = _loginService;
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString(UserConstants.USER_NAME);
            if (string.IsNullOrEmpty(userName))
                return RedirectToAction(nameof(Login));
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string passWordMD5 = EncryptUtil.EncryptMD5(model.UserName + model.Password);
                var user = loginService.checkLogin(model.UserName, passWordMD5);
                if (user != null)
                {
                    HttpContext.Session.SetString(UserConstants.USER_ID, user.Id.ToString());
                    HttpContext.Session.SetString(UserConstants.USER_NAME, user.UserName);
                    HttpContext.Session.SetString(UserConstants.USER_AVATAR, user.Avatar);
                    HttpContext.Session.SetString(UserConstants.IS_ADMIN, user.IsAdmin.ToString());
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //ViewBag.error = passWordMD5;
                    ViewBag.error = "username or pass không đúng or đã bị lock";
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult NotificationAuthorize()
        {
            return View();
        }
    }
}