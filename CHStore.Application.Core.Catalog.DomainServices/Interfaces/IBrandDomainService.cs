using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.DomainServices.Interfaces
{
    public interface IBrandDomainService
    {
        Task<Brand> Add(Brand brand);
        Task<Brand> Update(Brand brand);
        Task<IList<Brand>> Get();
        Task<Brand> Get(long brandId);
    }
}
