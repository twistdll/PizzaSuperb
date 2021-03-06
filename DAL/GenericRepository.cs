using DAL.Context;
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

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
            => await _db.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync();

        public async Task<List<T>> GetAllAsync()
        =>  await _db.Set<T>().AsNoTracking().ToListAsync();
        
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
            => await _db.Set<T>().AsNoTracking().Where(predicate).ToListAsync();

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
