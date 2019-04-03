using Microsoft.AspNetCore.Mvc;
using SieuNhanGao.Service.IServices;
using SieuNhanGaoBlog.Areas.Admin.Data;

namespace SieuNhanGaoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AuthorizeBusiness))]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        public IActionResult Index()
        {
            var users = userService.GetAll();
            return View(users);
        }
    }
}