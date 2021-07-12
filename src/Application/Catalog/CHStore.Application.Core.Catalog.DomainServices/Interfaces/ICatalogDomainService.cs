using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.DomainServices.Interfaces
{
    public interface ICatalogDomainService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> GetProduct(long productId);
        Task<IList<Product>> GetProducts();
        Task RemoveProduct(long productId);
        Task<bool> DebitStock(long productId, int mount = 1);
        Task<bool> IncreaseStock(long productId, int mount = 1);
        Task<IList<Product>> GetLastProducts(int mountOfProducts = 0, bool onlyActives = false);

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
