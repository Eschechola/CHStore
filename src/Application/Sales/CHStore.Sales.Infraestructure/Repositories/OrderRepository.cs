using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly SalesContext _context;

        public OrderRepository(SalesContext context)
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
