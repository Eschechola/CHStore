using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CHStore.Application.Core.Data.Repositories;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.Infra.Context;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        private readonly SalesContext _context;

        public CouponRepository(SalesContext context) : base(context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }

        public async Task<IList<Coupon>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            return await _context.Coupons
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.InitialDate == initialDate &&
                                x.FinalDate == finalDate
                         )
                         .ToListAsync();
        }

        public async Task<IList<Coupon>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate, bool searchActives = true)
        {
            return await _context.Coupons
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

        public async Task<IList<Coupon>> SearchCouponByCode(string code)
        {
            return await _context.Coupons
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.Code.ToLower().Contains(code)
                         )
                         .ToListAsync();
        }

        public async Task<IList<Coupon>> SearchCouponByCode(string code, bool searchActives = true)
        {
            return await _context.Coupons
                         .AsNoTracking()
                         .Where
                         (
                            x =>
                                x.Code.ToLower().Contains(code) &&
                                x.Active == searchActives
                         )
                         .ToListAsync();
        }
    }
}
