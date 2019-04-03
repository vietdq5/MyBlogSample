using Microsoft.AspNetCore.Mvc;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using SieuNhanGaoBlog.Models;
using System.Diagnostics;

namespace SieuNhanGaoBlog.Controllers
{
    public class HomeController : BaseController
    {
        private IPostService postService;
        private ICommentService commentService;

        public HomeController(IPostService _postService, ICommentService _commentService)
        {
            postService = _postService;
            commentService = _commentService;
        }
        public IActionResult Index(int page = 1)
        {
            var list = postService.GetAllPaging(string.Empty, page, 10);
            return View(list);
        }

        [Route("tim-kiem.html", Name = "Search")]
        public IActionResult Search(string keyword, int page = 1)
        {

            var list = postService.GetAllPaging(keyword, page, 10);
            return View(list);
        }

        [Route("categories/{categoryname}")]
        public IActionResult PostWithCategories(string categoryname, int page = 1)
        {
            var list = postService.GetAllPagingWithCategory(categoryname, page, 10);
            return View(list);
        }

        [Route("tags/{tagName}")]
        public IActionResult PostWithTags(string tagName, int page = 1)
        {
            var list = postService.GetAllPagingWithTag(tagName, page, 10);
            return View(list);
        }

        [Route("{Alias}-post.{id}.html")]
        public IActionResult Details(int id)
        {
            var model = postService.GetDetail(id);
            postService.IncreaseView(id);
            postService.Save();
            return View(model);
        }

        [Route("Home/AddComment")]
        [HttpPost]
        public JsonResult AddComment([FromBody]CommentViewModel commentViewModel)
        {
            bool stt = false;
            string msg = string.Empty;
            var comment = commentService.Add(commentViewModel);
            if (comment == null)
            {
                msg = "<div class='alert alert-success'>Comment thất bại</div>";
            }
            else
            {
                stt = true;
                msg = "<div class='alert alert-success'>Comment thành công và đang chờ duyệt</div>";
            }
            commentService.Save();
            return Json(new
            {
                status = stt,
                message = msg
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}