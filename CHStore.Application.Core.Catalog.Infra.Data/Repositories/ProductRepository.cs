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
            //desativa o rastreamento na consulta sql
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _context = context;
        }

        public async Task<IList<Product>> SearchBetweenPrices(decimal minimumPrice, decimal maximumPrice, bool searchActives = true)
        {
            var products = await (from prd in _context.Products

                                 where
                                    prd.Active == searchActives &&
                                    prd.Price >= minimumPrice &&
                                    prd.Price <= maximumPrice

                                 select prd).ToListAsync();

            return products;
        }

        public async Task<IList<Product>> SearchByBrand(long brandId, bool searchActives = true)
        {
            var products = await (from prd in _context.Products

                                  where
                                    prd.Active == searchActives &&
                                    prd.BrandId == brandId

                                  select prd).ToListAsync();

            return products;
        }

        public async Task<IList<Product>> SearchByCategory(long categoryId, bool searchActives = true)
        {
            var products = await (from prd in _context.Products

                                  where
                                     prd.Active == searchActives &&
                                     prd.CategoryId == categoryId

                                  select prd).ToListAsync();

            return products;
        }

        public async Task<IList<Product>> SearchByName(string name, bool searchActives = true)
        {
            var products = await (from prd in _context.Products

                                  where
                                     prd.Active == searchActives &&
                                     prd.Name.ToLower().Contains(name)

                                  select prd).ToListAsync();

            return products;
        }
    }
}
