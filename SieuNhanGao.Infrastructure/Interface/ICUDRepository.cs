namespace SieuNhanGao.Infrastructure.Interface
{
    public interface ICUDRepository<T> where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}