using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Context;
using CHStore.Application.Core.Data.Interfaces;

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

        public async Task<IList<Voucher>> SearchVoucherBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            return await _context.Vouchers
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.InitialDate == initialDate &&
                                x.FinalDate == finalDate
                         )
                         .ToListAsync();
        }

        public async Task<IList<Voucher>> SearchVoucherBetweenDates(DateTime initialDate, DateTime finalDate, bool searchActives = true)
        {
            return await _context.Vouchers
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.InitialDate == initialDate &&
                                x.FinalDate == finalDate &&
                                x.Active == searchActives
                         )
                         .ToListAsync();
        }

        public async Task<IList<Voucher>> SearchVoucherByCode(string code)
        {
            return await _context.Vouchers
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.Code.ToLower().Contains(code)
                         )
                         .ToListAsync();
        }

        public async Task<IList<Voucher>> SearchVoucherByCode(string code, bool searchActives = true)
        {
            return await _context.Vouchers
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.Code.ToLower().Contains(code) &&
                                x.Active == searchActives
                         )
                         .ToListAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }
    }
}
