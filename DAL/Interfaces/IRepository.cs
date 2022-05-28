using System.Linq.Expressions;

namespace DAL.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        void Insert(T entity);
        void Remove(T entity);
        void UpdateAsync(T entity);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

    }
}
