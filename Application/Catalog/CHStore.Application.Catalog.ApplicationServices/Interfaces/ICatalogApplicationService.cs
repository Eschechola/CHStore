using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Catalog.ApplicationServices.DTO;

namespace CHStore.Application.Catalog.ApplicationServices.Interfaces
{
    public interface ICatalogApplicationService : IDisposable
    {
        Task<ProductDTO> AddProduct(ProductDTO productDTO);
        Task<ProductDTO> UpdateProduct(ProductDTO productDTO);
        Task<ProductDTO> GetProduct(long productId);
        Task<IList<ProductDTO>> GetProducts();
        Task RemoveProduct(long productId);
        Task<IList<ProductDTO>> SearchProductsByCategory(long categoryId, bool searchActives = true);
        Task<IList<ProductDTO>> SearchProductsByBrand(long brandId, bool searchActives = true);
        Task<IList<ProductDTO>> SearchProductsByName(string name, bool searchActives = true);
        Task<IList<ProductDTO>> SearchProductsBetweenPrices(decimal minimumPrice, decimal maximumPrice, bool searchActives = true);
        Task<bool> DebitStock(long productId, long mount = 1);
        Task<bool> IncreaseStock(long productId, long mount = 1);

        Task<CategoryDTO> AddCategory(CategoryDTO categoryDTO);
        Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO);
        Task<CategoryDTO> GetCategory(long categoryId);
        Task<IList<CategoryDTO>> GetCategories();
        Task<IList<CategoryDTO>> SearchCategoriesByName(string name);

        Task<BrandDTO> AddBrand(BrandDTO brandDTO);
        Task<BrandDTO> UpdateBrand(BrandDTO brandDTO);
        Task<BrandDTO> GetBrand(long brandId);
        Task<IList<BrandDTO>> GetBrands();
        Task<IList<BrandDTO>> SearchBrandsByName(string name);
    }
}
