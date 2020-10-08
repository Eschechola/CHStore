using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHStore.Application.Core.Catalog.DomainServices.Services
{
    public class ProductDomainService : IProductDomainService
    {
        private readonly IProductRepository _productRepository;

        public ProductDomainService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Add(Product product)
        {
            return await _productRepository.Add(product);
        }

        public async Task<IList<Product>> Get()
        {
            return await _productRepository.Get();
        }

        public async Task<Product> Get(long productId)
        {
            return await _productRepository.Get(productId);
        }

        public async Task<IList<Product>> SearchBetweenPrices(decimal minimumPrice, decimal maximumPrice)
        {
            return await _productRepository.SearchBetweenPrices(minimumPrice, maximumPrice);
        }

        public async Task<IList<Product>> SearchByBrand(long brandId)
        {
            return await _productRepository.SearchByBrand(brandId);
        }

        public async Task<IList<Product>> SearchByCategory(long categoryId)
        {
            return await _productRepository.SearchByCategory(categoryId);
        }

        public async Task<IList<Product>> SearchByName(string name)
        {
            return await _productRepository.SearchByName(name);
        }

        public async Task<Product> Update(Product product)
        {
            return await _productRepository.Update(product);
        }
    }
}
