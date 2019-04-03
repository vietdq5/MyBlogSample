using SieuNhanGao.Service.ViewModels;

namespace SieuNhanGao.Service.IServices
{
    public interface IPostCategoryService
    {
        PostCategoryViewModel Add(PostCategoryViewModel postCategoryViewModel);

        void Save();
    }
}