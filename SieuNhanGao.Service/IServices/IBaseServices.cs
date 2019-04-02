using SieuNhanGao.Utilities.Dtos;

namespace SieuNhanGao.Service.IServices
{
    public interface IBaseServices<T> where T : class
    {
        PagedResult<T> GetAllPaging(string keyword, int page, int pageSize);

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}