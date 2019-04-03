using SieuNhanGao.Service.ViewModels;
using SieuNhanGao.Utilities.Dtos;
using System.Collections.Generic;

namespace SieuNhanGao.Service.IServices
{
    public interface IPostService
    {
        List<PostViewModel> GetLatest();

        IList<PostViewModel> GetAll();

        PagedResult<PostHomeViewModel> GetAllPaging(string keyword, int page, int pageSize);

        PagedResult<PostHomeViewModel> GetAllPagingWithCategory(string categoryName, int page, int pageSize);

        PagedResult<PostHomeViewModel> GetAllPagingWithTag(string tagName, int page, int pageSize);

        PostViewModel GetById(int id);

        DetailPostViewModel GetDetail(int id);

        PostViewModel Add(PostViewModel post);

        void Update(PostViewModel post);

        void Delete(int id);

        void IncreaseView(int id);

        void Save();
    }
}