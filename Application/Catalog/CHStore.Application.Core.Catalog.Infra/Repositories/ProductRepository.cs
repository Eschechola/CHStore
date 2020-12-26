using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Filters;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;

namespace CHStore.Application.Core.Catalog.Infra.Data.Repositories
{
    public class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)  : base(context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IList<Product>> SearchProduct(SearchProductFilter searchFilter)
        {
            IQueryable<Product> allProducts = _context.Products;

            if (searchFilter.ProductId != 0)
                return await allProducts.Where(x => x.Id == searchFilter.ProductId)
                                  .ToListAsync();

            if (searchFilter.OnlyActives)
                allProducts = allProducts.Where(x => x.Active == true);

            if (!string.IsNullOrEmpty(searchFilter.Name))
                allProducts = allProducts.Where(x => x.Name.ToLower() == searchFilter.Name.ToLower());

            if (searchFilter.CategoryId != 0)
                allProducts = allProducts.Where(x => x.CategoryId == searchFilter.CategoryId);

            if(searchFilter.BrandId != 0)
                allProducts = allProducts.Where(x => x.BrandId == searchFilter.BrandId);

            if (searchFilter.MinimumPrice <= 0)
                allProducts.Where(x => x.Price >= searchFilter.MinimumPrice);

            if(searchFilter.MaximumPrice > 0)
                allProducts.Where(x => x.Price <= searchFilter.MaximumPrice);

            if (searchFilter.MinimumStock > 0)
                allProducts.Where(x => x.Stock >= searchFilter.MinimumStock);

            if (searchFilter.MountOfProducts > 0)
                allProducts.Take(searchFilter.MountOfProducts);

            return await allProducts
                            .AsNoTracking()
                            .ToListAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
