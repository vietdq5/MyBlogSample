using System;
using System.Linq;
using System.Linq.Expressions;

namespace SieuNhanGao.Infrastructure.Interface
{
    public interface IReadRepository<T> where T : class
    {
        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
    }
}