using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace CHStore.Application.Core.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }

        void Create(T entity);
        void Update(T entity);
        void Remove(long id);
        Task<T> FindByIdAsync(long id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> query);
        Task<int> CountAsync(Expression<Func<T, bool>> query = null);
        Task<T> GetAsync(Expression<Func<T, bool>> query = null, string includeProperties = "", bool noTracking = true);
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> query = null, string includeProperties = "", bool noTracking = true);
    }
}
