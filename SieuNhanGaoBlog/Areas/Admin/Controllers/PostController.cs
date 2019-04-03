using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SieuNhanGao.Service.IServices;
using SieuNhanGao.Service.ViewModels;
using SieuNhanGao.Utilities.Constaint;
using SieuNhanGaoBlog.Areas.Admin.Data;
using System;

namespace SieuNhanGaoBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AuthorizeBusiness))]
    public class PostController : Controller
    {
        private IPostService postService;
        private ITagService tagService;
        private ICategoryService categoryService;
        private IPostCategoryService postCategoryService;

        public PostController(IPostService _postService, ITagService _tagService
            , ICategoryService _categoryService
            , IPostCategoryService _postCategoryService
            )
        {
            postService = _postService;
            tagService = _tagService;
            categoryService = _categoryService;
            postCategoryService = _postCategoryService;
        }

        public IActionResult Index()
        {
            var posts = postService.GetAll();
            return View(posts);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            var categories = categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "CategoryName");
            var userId = HttpContext.Session.GetString(UserConstants.USER_ID);
            var post = new PostViewModel
            {
                CreateDate = DateTime.Now,
                UserId = Int32.Parse(userId)
            };
            postService.Add(post);
            postService.Save();
            return View(post);
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,Content,Thumbnail,CreateDate,UpdateDate,Status,Alias,UserId,ViewCount")] PostViewModel postVm)
        {
            if (ModelState.IsValid)
            {
                postService.Add(postVm);
                postService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(postVm);
        }

        [Route("Admin/Post/AddCategory")]
        [HttpPost]
        public JsonResult AddCategory([FromBody]PostCategoryViewModel postCateVm)
        {
            bool stt = false;
            string msg = string.Empty;
            var comment = postCategoryService.Add(postCateVm);
            if (comment == null)
            {
                msg = "<div class='alert alert-success'>Add thất bại</div>";
            }
            else
            {
                stt = true;
                msg = "<div class='alert alert-success'>Add thành công</div>";
            }
            postCategoryService.Save();
            return Json(new
            {
                status = stt,
                message = msg
            });
        }
    }
}