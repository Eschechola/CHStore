using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;

namespace CHStore.Application.Core.Catalog.Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly CatalogContext _context;

        public CategoryRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }
    }
}
