using CHStore.Application.Core.Catalog.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Catalog.DomainServices.Interfaces
{
    public interface ICategoryDomainService
    {
        Task<Category> Add(Category category);
        Task<Category> Update(Category category);
        Task<IList<Category>> Get();
        Task<Category> Get(long categoryId);
    }
}
