using SieuNhanGao.Service.ViewModels;
using System.Collections.Generic;

namespace SieuNhanGao.Service.IServices
{
    public interface ICategoryService
    {
        IList<CategoryViewModel> GetAll();

        IList<CategoriesGroupViewModel> GetCategoriesGroup();

        void Save();
    }
}