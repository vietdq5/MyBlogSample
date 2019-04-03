using SieuNhanGao.Service.ViewModels;
using System.Collections.Generic;

namespace SieuNhanGao.Service.IServices
{
    public interface ITagService
    {
        IList<TagViewModel> GetAll();

        void Save();
    }
}