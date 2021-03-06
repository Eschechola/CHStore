﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Catalog.ApplicationServices.DTO;

namespace CHStore.Application.Catalog.ApplicationServices.Interfaces
{
    public interface ICatalogApplicationService
    {
        Task<ProductDTO> AddProduct(ProductDTO productDTO);
        Task<ProductDTO> UpdateProduct(ProductDTO productDTO);
        Task<ProductDTO> GetProduct(long productId);
        Task<IList<ProductDTO>> GetProducts();
        Task<IList<ProductDTO>> GetLastProducts(int mountOfProducts = 0, bool onlyActives = false);
        Task RemoveProduct(long productId);
        Task<bool> DebitStock(long productId, int mount = 1);
        Task<bool> IncreaseStock(long productId, int mount = 1);

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
