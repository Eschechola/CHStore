using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Core.Data.Interfaces;
namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class VoucherRepository : BaseRepository<Voucher>, IVoucherRepository
    {
        private readonly SalesContext _context;

        public VoucherRepository(SalesContext context)
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
