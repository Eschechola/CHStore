using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Core.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T: Entity
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public  async Task<T> Get(long id)
        {
            return await _context.Set<T>()
                .FindAsync(id);
        }

        public async Task<IList<T>> Get()
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> Add(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task Remove(long id)
        {
             _context.Set<T>().Remove(await Get(id));
             await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
    }
}
