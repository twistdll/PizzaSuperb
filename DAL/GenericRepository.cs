using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL
{
    internal class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly ApplicationContext _db;

        public GenericRepository(ApplicationContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db)); ;
        }

        public async Task<T?> GetAsync(T entity, Expression<Func<T, bool>> predicate)
            => await _db.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);

        public async void Insert(T entity)
        {
            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
        }

        public async void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async void UpdateAsync(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
