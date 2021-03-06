﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.DomainServices.Interfaces;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.ExtensionMethods;
using System.Linq.Expressions;

namespace CHStore.Application.Core.Catalog.DomainServices
{
    public class CatalogDomainService : ICatalogDomainService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CatalogDomainService(
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
            product.Validate();

            _productRepository.Create(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            product.Validate();

            Expression<Func<Product, bool>> expression = p => p.Id == product.Id;
            var productExists = await _productRepository.GetAsync(expression);

            if (productExists == null)
                throw new DomainException("O produto informado não existe na base de dados.");

            _productRepository.Update(product);
            await _productRepository.UnitOfWork.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProduct(long productId)
        {
            Expression<Func<Product, bool>> expression = p => p.Id == productId;

            return await _productRepository.GetAsync(expression);
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _productRepository.Get();
        }

        public async Task<IList<Product>> GetLastProducts(int mountOfProducts = 0, bool onlyActives = false)
        {
            Expression<Func<Product, bool>> searchExpression = p =>
                p.Active == onlyActives;

            return await _productRepository.Search(searchExpression, mountOfProducts);
        }

        public async Task RemoveProduct(long productId)
        {
            await _productRepository.Remove(productId);
            await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> DebitStock(long productId, int mount = 1)
        {
            if (mount <= 1)
                throw new DomainException("A Quantidade para ser debitada deve ser maior ou igual a 1.");

            var product = await _productRepository.Get(productId);

            if (!product.HasStock(mount))
                throw new DomainException("Não há estoque suficiente para ser debitado.");

            product.DecreaseStock(mount);

            await _productRepository.Update(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        public async Task<bool> IncreaseStock(long productId, int mount = 1)
        {
            if (mount <= 1)
                throw new DomainException("A Quantidade para ser aumentada deve ser maior ou igual a 1.");

            var product = await _productRepository.Get(productId);

            product.IncreaseStock(mount);

            await _productRepository.Update(product);

            return await _productRepository.UnitOfWork.Commit();
        }

        #endregion


        #region Categories

        public async Task<Category> AddCategory(Category category)
        {
            category.Validate();
            await _categoryRepository.Add(category);
            await _categoryRepository.UnitOfWork.Commit();

            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            category.Validate();

            var categoryExists = await _categoryRepository.Get(category.Id);

            if (categoryExists == null)
                throw new DomainException("A categoria informada não existe na base de dados.");

            await _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.Commit();

            return category;
        }

        public async Task<IList<Category>> GetCategories()
        {
            return await _categoryRepository.Get();
        }

        public async Task<Category> GetCategory(long categoryId)
        {
            return await _categoryRepository.Get(categoryId);
        }


        public async Task<IList<Category>> SearchCategoriesByName(string name)
        {
            Expression<Func<Category, bool>> searchExpression = p =>
                p.Name == name.FormatToSearchParammeter();

            return await _categoryRepository.Search(searchExpression);
        }

        #endregion


        #region Brands

        public async Task<Brand> AddBrand(Brand brand)
        {
            brand.Validate();
            await _brandRepository.Add(brand);
            await _brandRepository.UnitOfWork.Commit();

            return brand;
        }


        public async Task<Brand> UpdateBrand(Brand brand)
        {
            brand.Validate();

            var brandExists = await _brandRepository.Get(brand.Id);

            if (brandExists == null)
                throw new DomainException("A marca informada não existe na base de dados.");

            await _brandRepository.Update(brand);
            await _brandRepository.UnitOfWork.Commit();

            return brand;
        }
        public async Task<Brand> GetBrand(long brandId)
        {
            return await _brandRepository.Get(brandId);
        }

        public async Task<IList<Brand>> GetBrands()
        {
            return await _brandRepository.Get();
        }

        public async Task<IList<Brand>> SearchBrandsByName(string name)
        {
            Expression<Func<Brand, bool>> searchExpression = p =>
                p.Name == name.FormatToSearchParammeter();

            return await _brandRepository.Search(searchExpression);
        }

        #endregion
    }
}
