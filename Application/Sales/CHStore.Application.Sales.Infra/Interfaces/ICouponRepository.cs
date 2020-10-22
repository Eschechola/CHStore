using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public interface ICouponRepository : IBaseRepository<Coupon>, IDisposable
    {
        Task<IList<Coupon>> SearchCouponByCode(string code);
        Task<IList<Coupon>> SearchCouponByCode(string code, bool searchActives = true);
        Task<IList<Coupon>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate);
        Task<IList<Coupon>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate, bool searchActives = true);
    }
}
