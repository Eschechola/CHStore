using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CHStore.Application.Core.Catalog.Infra.Data.Interfaces
{
    public interface IBrandRepository : IBaseRepository<Brand>, IDisposable
    {
        Task<IList<Brand>> SearchByName(string name);
    }
}
