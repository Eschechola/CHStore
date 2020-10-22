using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.DomainServices.Interfaces;
using CHStore.Application.Sales.Infra.Interfaces;
using CHStore.Application.Core.Exceptions;

namespace CHStore.Application.Sales.DomainServices.Services
{
    public class SalesDomainService : ISalesDomainService, IDisposable
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITransportCompanyRepository _transportCompanyRepository;

        public SalesDomainService
        (
            ICouponRepository couponRepository,
            IOrderRepository orderRepository,
            ITransportCompanyRepository transportCompanyRepository
        )
        {
            _couponRepository = couponRepository;
            _orderRepository = orderRepository;
            _transportCompanyRepository = transportCompanyRepository;
        }


        #region Order

        public async Task<Order> CreateOrder(Order order)
        {
            return await _orderRepository.Add(order);
        }

        public async Task<Order> UpdateOrderStatus(long orderId, Status status)
        {
            var order = await GetOrder(orderId);

            if (order == null)
                throw new DomainException("O pedido não foi encontrado.");

            order.Status.Add(status);

            return await _orderRepository.Update(order);
        }

        public async Task<Order> GetOrder(long orderId)
        {
            return await _orderRepository.Get(orderId);
        }

        public async Task<IList<Order>> GetAllOrders()
        {
            return await _orderRepository.Get();
        }

        public async Task<IList<Order>> SearchOrdersByCustomerId(long customerId)
        {
            return await _orderRepository.SearchOrdersByCustomerId(customerId);
        }

        public async Task<IList<Order>> SearchByStatus(Status status)
        {
            return await _orderRepository.SearchByStatus(status);
        }

        public async Task<IList<Order>> SearchOrderBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            return await _orderRepository.SearchOrderBetweenDates(initialDate, finalDate);
        }
        public async Task<IList<Order>> SearchOrderBetweenPrices(decimal initialPrice, decimal finalPrice)
        {
            return await _orderRepository.SearchOrderBetweenPrices(initialPrice, finalPrice);
        }

        #endregion

        #region Coupon

        public async Task<Coupon> AddCoupon(Coupon coupon)
        {
            return await _couponRepository.Add(coupon);
        }

        public async Task<Coupon> UpdateCoupon(Coupon coupon)
        {
            return await _couponRepository.Update(coupon);
        }

        public async Task<Coupon> GetCoupon(long couponId)
        {
            return await _couponRepository.Get(couponId);
        }

        public async Task<IList<Coupon>> GetCoupons()
        {
            return await _couponRepository.Get();
        }

        public async Task ActivateCoupon(Coupon coupon)
        {
            coupon.ActivateCoupon();
            await UpdateCoupon(coupon);
        }
        
        public async Task DeactivateCoupon(Coupon coupon)
        {
            coupon.DeactivateCoupon();
            await UpdateCoupon(coupon);
        }
        
        public async Task<IList<Coupon>> SearchCouponBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            return await _couponRepository.SearchCouponBetweenDates(initialDate, finalDate);
        }

        public async Task<IList<Coupon>> SearchCouponByCode(string code)
        {
            return await _couponRepository.SearchCouponByCode(code);
        }

        public async Task<IList<Coupon>> SearchCouponByCode(string code, bool searchActives)
        {
            return await _couponRepository.SearchCouponByCode(code, searchActives);
        }

        #endregion

        #region TransportCompany

        public async Task<TransportCompany> AddTransportCompany(TransportCompany transportCompany)
        {
            return await _transportCompanyRepository.Add(transportCompany);
        }

        public async Task<TransportCompany> UpdateTransportCompany(TransportCompany transportCompany)
        {
            return await _transportCompanyRepository.Update(transportCompany);
        }

        public async Task ActivateTransportCompany(TransportCompany transportCompany)
        {
            transportCompany.ActivateTransportCompany();
            await UpdateTransportCompany(transportCompany);
        }
        public async Task DeactivateTransportCompany(TransportCompany transportCompany)
        {
            transportCompany.DeactivateTransportCompany();
            await UpdateTransportCompany(transportCompany);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            _couponRepository?.Dispose();
            _transportCompanyRepository?.Dispose();
            _orderRepository?.Dispose();
        }

        #endregion
    }
}
