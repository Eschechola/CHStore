using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Interfaces;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace CHStore.Application.Core.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: Entity
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        IUnitOfWork IBaseRepository<T>.UnitOfWork => null;

        public virtual async Task<T> Get(long id)
        {
            return await _context.Set<T>()
                .FindAsync(id);
        }

        public virtual async Task<IList<T>> Get()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T> Add(T obj)
        {
            await _context.Set<T>().AddAsync(obj);

            return obj;
        }

        public virtual async Task Remove(long id)
        {
             _context.Set<T>().Remove(await Get(id));
        }

        public virtual async Task<T> Update(T obj)
        {
            await Task.Run(() =>
            {
                _context.Entry(obj).State = EntityState.Modified;
            });

            return obj;
        }

        public virtual async Task<IQueryable<T>> SearchQuery(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> itens = _context.Set<T>();

            await Task.Run(() => 
            {
                itens = itens.Where(expression);
            });

            return itens;
        }

        public virtual async Task<IList<T>> Search(Expression<Func<T, bool>> expression)
        {
            var itens = _context.Set<T>()
                                .Where(expression);
            return await itens
                            .AsNoTracking()
                            .ToListAsync();
        }

        public virtual async Task<IList<T>> Search(Expression<Func<T, bool>> expression, int mountOfItens = 0)
        {
            var itens = _context.Set<T>()
                            .Where(expression);

            return await itens
                .AsNoTracking()
                .Take(mountOfItens)
                .ToListAsync();
        }
    }
}
