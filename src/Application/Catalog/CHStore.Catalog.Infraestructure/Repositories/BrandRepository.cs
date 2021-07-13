
using CHStore.Application.Core.Catalog.Infra.Data.Context;
using CHStore.Application.Core.Catalog.Infra.Data.Interfaces;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Catalog.Domain.Entities;

namespace CHStore.Application.Core.Catalog.Infra.Data.Repositories
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly CatalogContext _context;

        public BrandRepository(CatalogContext context)
            : base(context)
        {
            _context = context;
        }

        public override IUnitOfWork UnitOfWork
        {
            get { return UoW; }
        }

        private IUnitOfWork UoW => _context;
    }
}
