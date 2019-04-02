using SieuNhanGao.Infrastructure.Interface;
using System;

namespace SieuNhanGao.Data
{
    public class CUDEFRepository<T> : ICUDRepository<T>, IDisposable
        where T : class
    {
        private readonly AppDbContext dbContext;

        public CUDEFRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Add(T entity)
        {
            dbContext.Add(entity);
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        public void Remove(T entity)
        {
            dbContext.Remove(entity);
        }

        public void Update(T entity)
        {
            dbContext.Update(entity);
        }
    }
}