using System.Threading.Tasks;
using System.Collections.Generic;

namespace CHStore.Application.Core.Data.Interfaces
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> Add(T item);

        Task<T> Update(T item);

        Task Remove(int id);

        Task<T> Get(int id);

        Task<IList<T>> Get();
    }
}
