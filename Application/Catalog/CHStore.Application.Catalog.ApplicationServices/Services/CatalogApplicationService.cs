using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Core.ExtensionMethods;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Catalog.ApplicationServices.DTO;
using CHStore.Application.Catalog.ApplicationServices.Interfaces;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;

namespace CHStore.Application.Catalog.ApplicationServices
{
    public class CatalogApplicationService : ICatalogApplicationService, IDisposable
    {

        #region Properties

        private readonly IMapper _mapper;
        private readonly ICatalogDomainService _catalogDomainService;

        #endregion

        #region Constructors

        public CatalogApplicationService(IMapper mapper, ICatalogDomainService catalogDomainService)
        {
            _mapper = mapper;
            _catalogDomainService = catalogDomainService;
        }

        #endregion

        #region Product

        public async Task<ProductDTO> AddProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            var productInserted = await  _catalogDomainService.AddProduct(product);

            return _mapper.Map<ProductDTO>(productInserted);
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            var productUpdated = await _catalogDomainService.UpdateProduct(product);

            return _mapper.Map<ProductDTO>(productUpdated);
        }

        public async Task<ProductDTO> GetProduct(long productId)
        {
            var product = await _catalogDomainService.GetProduct(productId);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IList<ProductDTO>> GetProducts()
        {
            var products = await _catalogDomainService.GetProducts();

            return _mapper.Map<IList<ProductDTO>>(products);
        }

        public async Task<IList<ProductDTO>> GetLastProducts(int mountOfProducts = 0, bool onlyActives = false)
        {
            var products = await _catalogDomainService.GetLastProducts(mountOfProducts: mountOfProducts, onlyActives: onlyActives);

            return _mapper.Map<IList<ProductDTO>>(products);
        }

        public async Task RemoveProduct(long productId)

        {
            await _catalogDomainService.RemoveProduct(productId);
        }

        public async Task<bool> DebitStock(long productId, int mount = 1)
        {
            return await _catalogDomainService.DebitStock(productId, mount);
        }

        public async Task<bool> IncreaseStock(long productId, int mount = 1)
        {
            return await _catalogDomainService.IncreaseStock(productId, mount);
        }

        #endregion

        #region Category

        public async Task<CategoryDTO> AddCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            var categoryInserted = await _catalogDomainService.AddCategory(category);

            return _mapper.Map<CategoryDTO>(categoryInserted);
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);

            var categoryUpdated = await _catalogDomainService.UpdateCategory(category);

            return _mapper.Map<CategoryDTO>(categoryUpdated);
        }

        public async Task<IList<CategoryDTO>> GetCategories()
        {
            var categories = await _catalogDomainService.GetCategories();

            return _mapper.Map<IList<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategory(long categoryId)
        {
            var category = await _catalogDomainService.GetCategory(categoryId);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IList<CategoryDTO>> SearchCategoriesByName(string name)
        {
            name = name.FormatToSearchParammeter();
            var categories = await _catalogDomainService.SearchCategoriesByName(name);

            return _mapper.Map<IList<CategoryDTO>>(categories);
        }

        #endregion

        #region Brand

        public async Task<BrandDTO> AddBrand(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);

            var brandInserted = await _catalogDomainService.AddBrand(brand);

            return _mapper.Map<BrandDTO>(brandInserted);
        }

        public async Task<BrandDTO> UpdateBrand(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);

            var brandUpdated = await _catalogDomainService.UpdateBrand(brand);

            return _mapper.Map<BrandDTO>(brandUpdated);
        }

        public async Task<BrandDTO> GetBrand(long brandId)
        {
            var brand = await _catalogDomainService.GetBrand(brandId);

            return _mapper.Map<BrandDTO>(brand);
        }
        
        public async Task<IList<BrandDTO>> GetBrands()
        {
            var brands = await _catalogDomainService.GetBrands();

            return _mapper.Map<IList<BrandDTO>>(brands);
        }

        public async Task<IList<BrandDTO>> SearchBrandsByName(string name)
        {
            name = name.FormatToSearchParammeter();
            var brands = await _catalogDomainService.SearchBrandsByName(name);

            return _mapper.Map<IList<BrandDTO>>(brands);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _catalogDomainService?.Dispose();
        }

        #endregion
    }
}
