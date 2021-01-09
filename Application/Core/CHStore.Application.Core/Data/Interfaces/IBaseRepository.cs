using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace CHStore.Application.Core.Data.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> Add(T item);

        Task<T> Update(T item);

        Task Remove(long id);

        Task<T> Get(long id);

        Task<IList<T>> Get();

        Task<IQueryable<T>> SearchQuery(Expression<Func<T, bool>> expression);
        
        Task<IList<T>> Search(Expression<Func<T, bool>> expression);

        Task<IList<T>> Search(Expression<Func<T, bool>> expression, int mountOfItens = 0);

    }
}
