using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Core.Catalog.Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly CatalogContext _context;

        public CategoryRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }

        public override IUnitOfWork UnitOfWork
        {
            get { return _context; }
            protected set { UnitOfWork = value; }
        }

        public async Task<IList<Category>> SearchByName(string name)
        {
            return await _context.Categories
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.Name.ToLower().Contains(name)
                         )
                         .ToListAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
