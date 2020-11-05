using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.DomainServices.Interfaces;
using CHStore.Application.Sales.Infra.Interfaces;
using CHStore.Application.Core.Exceptions;

namespace CHStore.Application.Sales.DomainServices
{
    public class SalesDomainService : ISalesDomainService, IDisposable
    {
        private readonly IVoucherRepository _couponRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITransportCompanyRepository _transportCompanyRepository;

        public SalesDomainService
        (
            IVoucherRepository couponRepository,
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
            //order.Validate();
            await _orderRepository.Add(order);
            await _orderRepository.UnitOfWork.Commit();

            return order;
        }

        public async Task<Order> UpdateOrderStatus(long orderId, Status status)
        {
            var order = await GetOrder(orderId);

            if (order == null)
                throw new DomainException("O pedido não foi encontrado.");

            order.Status.Add(status);

            await _orderRepository.Update(order);
            await _orderRepository.UnitOfWork.Commit();

            return order;
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

        public async Task<IList<Order>> SearchOrderByStatus(Status status)
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

        #region Voucher

        public async Task<Voucher> AddVoucher(Voucher voucher)
        {
            await _couponRepository.Add(voucher);
            await _couponRepository.UnitOfWork.Commit();

            return voucher;
        }

        public async Task<Voucher> UpdateVoucher(Voucher voucher)
        {
            await _couponRepository.Update(voucher);
            await _couponRepository.UnitOfWork.Commit();

            return voucher;
        }

        public async Task<Voucher> GetVoucher(long voucherId)
        {
            return await _couponRepository.Get(voucherId);
        }

        public async Task<IList<Voucher>> GetVouchers()
        {
            return await _couponRepository.Get();
        }

        public async Task ActivateVoucher(Voucher voucher)
        {
            voucher.ActivateVoucher();
            await UpdateVoucher(voucher);
        }
        
        public async Task DeactivateVoucher(Voucher voucher)
        {
            voucher.DeactivateVoucher();
            await UpdateVoucher(voucher);
        }
        
        public async Task<IList<Voucher>> SearchVoucherBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            return await _couponRepository.SearchVoucherBetweenDates(initialDate, finalDate);
        }

        public async Task<IList<Voucher>> SearchVoucherByCode(string code)
        {
            return await _couponRepository.SearchVoucherByCode(code);
        }

        public async Task<IList<Voucher>> SearchVoucherByCode(string code, bool searchActives)
        {
            return await _couponRepository.SearchVoucherByCode(code, searchActives);
        }

        #endregion

        #region TransportCompany

        public async Task<TransportCompany> AddTransportCompany(TransportCompany transportCompany)
        {
            await _transportCompanyRepository.Add(transportCompany);
            await _transportCompanyRepository.UnitOfWork.Commit();

            return transportCompany;
        }

        public async Task<TransportCompany> UpdateTransportCompany(TransportCompany transportCompany)
        {
            await _transportCompanyRepository.Update(transportCompany);
            await _transportCompanyRepository.UnitOfWork.Commit();

            return transportCompany;
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
