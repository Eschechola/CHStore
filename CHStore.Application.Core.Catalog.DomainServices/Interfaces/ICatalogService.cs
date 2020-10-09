using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.DomainServices.Interfaces
{
    public interface ICatalogService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> GetProduct(long productId);
        Task<IList<Product>> GetProducts();
        Task RemoveProduct(long productId);
        Task<IList<Product>> SearchProductsByCategory(long categoryId, bool searchActives = true);
        Task<IList<Product>> SearchProductsByBrand(long brandId, bool searchActives = true);
        Task<IList<Product>> SearchProductsByName(string name, bool searchActives = true);
        Task<IList<Product>> SearchProductsBetweenPrices(decimal minimumPrice, decimal maximumPrice, bool searchActives = true);

        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> GetCategory(long categoryId);
        Task<IList<Category>> GetCategories();
        Task<IList<Category>> SearchCategoriesByName(string name);

        Task<Brand> AddBrand(Brand brand);
        Task<Brand> UpdateBrand(Brand brand);
        Task<Brand> GetBrand(long brandId);
        Task<IList<Brand>> GetBrands();
        Task<IList<Brand>> SearchBrandsByName(string name);
    }
}
