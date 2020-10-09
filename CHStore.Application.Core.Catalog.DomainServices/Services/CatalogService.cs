using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using CHStore.Application.Core.ExtensionMethods;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Catalog.DomainServices.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CatalogService(
            IBrandRepository brandRepository,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository
        )
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        #region Products

        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.Add(product);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await _productRepository.Update(product);
        }

        public async Task<Product> GetProduct(long productId)
        {
            return await _productRepository.Get(productId);
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _productRepository.Get();
        }

        public async Task RemoveProduct(long productId)
        {
            await _productRepository.Remove(productId);
        }

        public async Task<IList<Product>> SearchProductsBetweenPrices(decimal minimumPrice, decimal maximumPrice, bool searchActives = true)
        {
            return await _productRepository.SearchBetweenPrices(minimumPrice, maximumPrice, searchActives);
        }

        public async Task<IList<Product>> SearchProductsByBrand(long brandId, bool searchActives = true)
        {
            return await _productRepository.SearchByBrand(brandId, searchActives);
        }

        public async Task<IList<Product>> SearchProductsByCategory(long categoryId, bool searchActives = true)
        {
            return await _productRepository.SearchByCategory(categoryId, searchActives);
        }

        public async Task<IList<Product>> SearchProductsByName(string name, bool searchActives = true)
        {
            name.FormatToSearchParammeter();
            return await _productRepository.SearchByName(name, searchActives);
        }

        #endregion


        #region Categories

        public async Task<Category> AddCategory(Category category)
        {
            return await _categoryRepository.Add(category);
        }

        public async Task<IList<Category>> GetCategories()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> GetCategory(long categoryId)
        {
            return await _categoryRepository.Get(categoryId);
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            return await _categoryRepository.Update(category);
        }

        public async Task<IList<Category>> SearchCategoriesByName(string name)
        {
            name.FormatToSearchParammeter();
            return await _categoryRepository.SearchByName(name);
        }

        #endregion


        #region Brands

        public async Task<Brand> AddBrand(Brand brand)
        {
            return await _brandRepository.Add(brand);
        }

        public async Task<Brand> GetBrand(long brandId)
        {
            return await _brandRepository.Get(brandId);
        }

        public async Task<IList<Brand>> GetBrands()
        {
            return await _brandRepository.Get();
        }

        public async Task<Brand> UpdateBrand(Brand brand)
        {
            return await _brandRepository.Update(brand);
        }

        public async Task<IList<Brand>> SearchBrandsByName(string name)
        {
            name.FormatToSearchParammeter();
            return await _brandRepository.SearchByName(name);
        }

        #endregion
    }
}
