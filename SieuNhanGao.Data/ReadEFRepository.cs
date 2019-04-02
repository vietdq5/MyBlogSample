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

        // Expression<Func<T, object>>[]includeProperties: truyền vào các thuộc tính cần get ra
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

        // Expression<Func<T, bool>> filter: truyền vào một filter expression dạng LINQ 
        public IQueryable<T> FindAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = dbContext.Set<T>();
            // duyệt qua các propeties của T để thêm vào filter
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(filter);
        }

        // get ra T theo filter và các properties cần get
        public T FindSingle(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(filter);
        }
    }
}