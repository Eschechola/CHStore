using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Catalog.Infra.Data.Interfaces
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        Task<IList<Brand>> SearchByName(string name);
    }
}
