using System;
using System.Linq;
using System.Linq.Expressions;

namespace SieuNhanGao.Infrastructure.Interface
{
    public interface IReadRepository<T> where T : class
    {
        // find single with filter is linq expression and eager loading/or lazy loading
        T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        
        // find all with eager loading or lazy loading
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        // find all with filter is linq expression and eager loading/or lazy loading
        IQueryable<T> FindAll(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includeProperties);

        // find all with filter is linq expression, eager loading/or lazy loading and properties of entity need get
        IQueryable<T> FindAll(Expression<Func<T, bool>> filter,string properties="");
    }
}