using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Sales.Infra.Interfaces
{
    public interface ICouponRepository : IBaseRepository<Coupon>
    {
        Task<IList<Coupon>> SearchCouponByCode(string code);
        Task<IList<Coupon>> SearchCouponByCode(string code, bool active);
        Task<IList<Order>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate);
    }
}
