using CHStore.Application.Core.Catalog.Domain.Entities;
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using CHStore.Application.Core.Data.Repositories;

namespace CHStore.Application.Core.Catalog.Infra.Data.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly CatalogContext _context;

        public BrandRepository(CatalogContext context) : base(context)
        {
            _context = context;
        }
    }
}
