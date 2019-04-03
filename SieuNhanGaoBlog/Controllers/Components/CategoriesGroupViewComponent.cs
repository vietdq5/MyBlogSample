using Microsoft.AspNetCore.Mvc;
using SieuNhanGao.Service.IServices;
using System.Threading.Tasks;

namespace SieuNhanGaoBlog.Controllers.Components
{
    public class CategoriesGroupViewComponent : ViewComponent
    {
        private ICategoryService categoryService;

        public CategoriesGroupViewComponent(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryGroup = categoryService.GetCategoriesGroup();
            return await Task.FromResult((IViewComponentResult)View("CategoriesGroup", categoryGroup));
        }
    }
}