using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class VoucherRepository : BaseRepository<Voucher>, IVoucherRepository
    {
        private readonly SalesContext _context;

        public VoucherRepository(SalesContext context) : base(context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IList<Voucher>> Search(SearchVoucherFilter searchFilter)
        {
            IQueryable<Voucher> allVouchers = _context.Vouchers;

            if (searchFilter.VoucherId != 0)
                return await allVouchers.Where(x => x.Id == searchFilter.VoucherId)
                                        .ToListAsync();

            if (!string.IsNullOrEmpty(searchFilter.Code))
                allVouchers = allVouchers.Where(x => x.Code.ToLower().Contains(searchFilter.Code.ToLower()));

            if (searchFilter.InitialDate != null)
                allVouchers = allVouchers.Where(x => x.InitialDate >= searchFilter.InitialDate);

            if (searchFilter.FinalDate != null)
                allVouchers = allVouchers.Where(x => x.FinalDate <= searchFilter.FinalDate);

            return await allVouchers.AsNoTracking().ToListAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
