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

        public ProductRepository(CatalogContext context)
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
