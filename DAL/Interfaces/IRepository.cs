using System.Linq.Expressions;

namespace DAL.Interfaces
{
    internal interface IRepository<T>
        where T : class
    {
        void Insert(T entity);
        void Remove(T entity);
        void UpdateAsync(T entity);
        Task<T?> GetAsync(T entity, Expression<Func<T, bool>> predicate);

    }
}
