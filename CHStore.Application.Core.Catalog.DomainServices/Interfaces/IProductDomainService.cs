using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.DomainServices.Interfaces
{
    public interface IProductDomainService
    {
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task<IList<Product>> Get();
        Task<Product> Get(long productId);
        Task<IList<Product>> SearchByCategory(long categoryId);
        Task<IList<Product>> SearchByBrand(long brandId);
        Task<IList<Product>> SearchByName(string name);
        Task<IList<Product>> SearchBetweenPrices(decimal minimumPrice, decimal maximumPrice);
    }
}
