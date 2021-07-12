using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Interfaces;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace CHStore.Application.Core.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> 
        where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public abstract IUnitOfWork UnitOfWork { get; }

        public void Create(T entity)
            => _dbSet.Add(entity);

        public void Update(T entity)
            => _context.Entry(entity).State = EntityState.Modified;

        public async void Remove(long id)
            => _dbSet.Remove(await FindByIdAsync(id));

        public async Task<T> FindByIdAsync(long id)
            => await _dbSet.Where(x => x.Id == id)
                .FirstOrDefaultAsync();

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> query)
            => await _dbSet.AnyAsync(query);

        public async Task<int> CountAsync(Expression<Func<T, bool>> query = null)
            => query == null
                ? await _dbSet.CountAsync()
                : await _dbSet.CountAsync(query);

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> query = null,
            string includeProperties = "",
            bool noTracking = true)
            => noTracking
                ? await FindAll(query, includeProperties).AsNoTracking().FirstOrDefaultAsync()
                : await FindAll(query, includeProperties).FirstOrDefaultAsync();

        public async Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>> query = null,
            string includeProperties = "",
            bool noTracking = true)
            => noTracking
                ? await FindAll(query, includeProperties).AsNoTracking().ToListAsync()
                : await FindAll(query, includeProperties).ToListAsync();

        private IQueryable<T> FindAll(
            Expression<Func<T, bool>> predicate = null,
            string includeProperties = "")
        {
            var queryable = _dbSet as IQueryable<T>;

            if (predicate != null)
                queryable = queryable.Where(predicate);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                queryable = queryable.Include(includeProperty);

            return queryable;
        }
    }
}
