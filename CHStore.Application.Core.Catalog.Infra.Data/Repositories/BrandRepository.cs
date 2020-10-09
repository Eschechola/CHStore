using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CHStore.Application.Core.Catalog.Infra.Data.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly CatalogContext _context;

        public BrandRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Brand>> SearchByName(string name)
        {
            var brands = await (from brd in _context.Brands

                                  where
                                    brd.Name.ToLower().Contains(name)

                                  select brd).ToListAsync();

            return brands;
        }
    }
}
