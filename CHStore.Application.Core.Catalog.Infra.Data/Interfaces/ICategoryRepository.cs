using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Catalog.Infra.Data.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IList<Category>> SearchByName(string name);
    }
}
