using System.Linq;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CHStore.Application.Core.Catalog.Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly CatalogContext _context;

        public CategoryRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<Category>> SearchByName(string name)
        {
            var categories = await (from ctg in _context.Categories

                                  where
                                    ctg.Name.ToLower().Contains(name)

                                  select ctg).ToListAsync();

            return categories;
        }
    }
}
