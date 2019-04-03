using Microsoft.AspNetCore.Mvc;
using SieuNhanGao.Utilities.Dtos;
using System.Threading.Tasks;

namespace SieuNhanGaoBlog.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}