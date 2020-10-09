using System.Collections.Generic;
using System.Threading.Tasks;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Core.Catalog.Infra.Data.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IList<Product>> SearchByCategory(long categoryId, bool searchActives = true);
        Task<IList<Product>> SearchByBrand(long brandId, bool searchActives = true);
        Task<IList<Product>> SearchByName(string name, bool searchActives = true);
        Task<IList<Product>> SearchBetweenPrices(decimal minimumPrice, decimal maximumPrice, bool searchActives = true);
    }
}
