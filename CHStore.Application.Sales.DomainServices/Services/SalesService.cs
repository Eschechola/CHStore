using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.DomainServices.Interfaces;

namespace CHStore.Application.Sales.DomainServices.Services
{
    public class SalesService : ISalesService
    {
        #region Order
        
        public async Task<Order> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> UpdateStatus(long orderId, Status status)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrder(long orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Order>> SearchOrdersByUserId(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Order>> SearchByStatus(Status status)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Order>> SearchOrderBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            throw new NotImplementedException();
        }
        public async Task<IList<Order>> SearchOrderBetweenPrices(decimal initialPrice, decimal finalPrice)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Coupon

        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<Coupon> UpdateCoupon(Coupon coupon)
        {
            throw new NotImplementedException();
        }

        public async Task<Coupon> GetCoupons(long couponId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Coupon>> GetCoupons()
        {
            throw new NotImplementedException();
        }

        public async Task ActivateCoupon(Coupon coupon)
        {
            throw new NotImplementedException();
        }
        
        public async Task DeactivateCoupon(Coupon coupon)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IList<Order>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Coupon>> SearchCouponByCode(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Coupon>> SearchCouponByCode(string code, bool active)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TransportCompany

        public async Task<TransportCompany> AddTransportCompany(TransportCompany transportCompany)
        {
            throw new NotImplementedException();
        }

        public async Task<TransportCompany> UpdateTransportCompany(TransportCompany transportCompany)
        {
            throw new NotImplementedException();
        }

        public async Task ActivateTransportCompany(TransportCompany transportCompany)
        {
            throw new NotImplementedException();
        }
        public async Task DeactivateTransportCompany(TransportCompany transportCompany)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
