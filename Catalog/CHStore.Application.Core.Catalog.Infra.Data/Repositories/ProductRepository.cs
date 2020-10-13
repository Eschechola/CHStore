using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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

        public void Dispose()
        {
            _context?.DisposeAsync();
        }

        public async Task<IList<Product>> SearchBetweenPrices(decimal minimumPrice, decimal maximumPrice, bool searchActives = true)
        {
            return await _context.Products
                                 .AsNoTracking()
                                 .Where
                                 (
                                    x =>
                                        x.Price >= minimumPrice &&
                                        x.Price <= maximumPrice &&
                                        x.Active == searchActives
                                 ).ToListAsync();
        }

        public async Task<IList<Product>> SearchByBrand(long brandId, bool searchActives = true)
        {
            return await _context.Products
                                 .AsNoTracking()
                                 .Where
                                 (
                                    x =>
                                        x.BrandId == brandId &&
                                        x.Active == searchActives
                                 ).ToListAsync();
        }

        public async Task<IList<Product>> SearchByCategory(long categoryId, bool searchActives = true)
        {
            return await _context.Products
                                 .AsNoTracking()
                                 .Where
                                 (
                                    x =>
                                        x.CategoryId == categoryId &&
                                        x.Active == searchActives
                                 ).ToListAsync();
        }

        public async Task<IList<Product>> SearchByName(string name, bool searchActives = true)
        {
            return await _context.Products
                                 .AsNoTracking()
                                 .Where
                                 (
                                    x =>
                                        x.Name.ToLower() == name &&
                                        x.Active == searchActives
                                 ).ToListAsync();
        }
    }
}
