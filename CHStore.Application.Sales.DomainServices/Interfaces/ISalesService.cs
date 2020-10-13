using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using System;

namespace CHStore.Application.Sales.DomainServices.Interfaces
{
    public interface ISalesService
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrder(long orderId);
        Task<Order> GetAllOrders();
        Task<Order> UpdateStatus(long orderId, Status status);
        Task<IList<Order>> SearchOrdersByUserId(long userId);
        Task<IList<Order>> SearchOrderBetweenDates(DateTime initialDate, DateTime finalDate);
        Task<IList<Order>> SearchOrderBetweenPrices(decimal initialPrice, decimal finalPrice);
        Task<IList<Order>> SearchByStatus(Status status);

        Task<Coupon> AddCoupon(Coupon coupon);
        Task<Coupon> UpdateCoupon(Coupon coupon);
        Task<IList<Coupon>> GetCoupons();
        Task<Coupon> GetCoupons(long couponId);
        Task<IList<Coupon>> SearchCouponByCode(string code);
        Task<IList<Coupon>> SearchCouponByCode(string code, bool active);
        Task<IList<Order>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate);
        Task ActivateCoupon(Coupon coupon);
        Task DeactivateCoupon(Coupon coupon);

        Task<TransportCompany> AddTransportCompany(TransportCompany transportCompany);
        Task<TransportCompany> UpdateTransportCompany(TransportCompany transportCompany);
        Task ActivateTransportCompany(TransportCompany transportCompany);
        Task DeactivateTransportCompany(TransportCompany transportCompany);
    }
}
