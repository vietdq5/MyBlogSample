using Microsoft.EntityFrameworkCore;
using SieuNhanGao.Infrastructure.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SieuNhanGao.Data
{
    public class ReadEFRepository<T> : IReadRepository<T>, IDisposable
       where T : class
    {
        private readonly AppDbContext dbContext;

        public ReadEFRepository(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = dbContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = dbContext.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(filter);
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> filter, string properties = "")
        {
            IQueryable<T> items = dbContext.Set<T>();
            if (!string.IsNullOrEmpty(properties))
            {
                foreach (var property in properties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    items = items.Include(property);
                }
            }
            return items.Where(filter);
        }

        public T FindSingle(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(filter);
        }
    }
}