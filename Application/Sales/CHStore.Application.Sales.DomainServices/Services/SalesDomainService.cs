using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.DomainServices.Interfaces;
using CHStore.Application.Sales.Infra.Interfaces;
using CHStore.Application.Core.Exceptions;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Sales.DomainServices
{
    public class SalesDomainService : ISalesDomainService, IDisposable
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITransportCompanyRepository _transportCompanyRepository;

        public SalesDomainService
        (
            IVoucherRepository couponRepository,
            IOrderRepository orderRepository,
            ITransportCompanyRepository transportCompanyRepository
        )
        {
            _voucherRepository = couponRepository;
            _orderRepository = orderRepository;
            _transportCompanyRepository = transportCompanyRepository;
        }


        #region Order

        public async Task<Order> CreateOrder(Order order)
        {
            order.Validate();            
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

            order.Validate();

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

        public async Task<IList<Order>> SearchOrders(SearchOrderFilter searchFilter)
        {
            return await _orderRepository.Search(searchFilter);
        }

        #endregion

        #region Voucher

        public async Task<Voucher> AddVoucher(Voucher voucher)
        {
            voucher.Validate();
            await _voucherRepository.Add(voucher);
            await _voucherRepository.UnitOfWork.Commit();

            return voucher;
        }

        public async Task<Voucher> UpdateVoucher(Voucher voucher)
        {
            voucher.Validate();

            var voucherExists = _voucherRepository.Get(voucher.Id);

            if (voucherExists == null)
                throw new DomainException("O cupom informado não existe na base de dados.");

            await _voucherRepository.Update(voucher);
            await _voucherRepository.UnitOfWork.Commit();

            return voucher;
        }

        public async Task<Voucher> GetVoucher(long voucherId)
        {
            return await _voucherRepository.Get(voucherId);
        }

        public async Task<IList<Voucher>> GetVouchers()
        {
            return await _voucherRepository.Get();
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

        public async Task<IList<Voucher>> SearchVoucher(SearchVoucherFilter searchFilter)
        {
            return await _voucherRepository.Search(searchFilter);
        }

        #endregion

        #region TransportCompany

        public async Task<TransportCompany> AddTransportCompany(TransportCompany transportCompany)
        {
            transportCompany.Validate();
            await _transportCompanyRepository.Add(transportCompany);
            await _transportCompanyRepository.UnitOfWork.Commit();

            return transportCompany;
        }

        public async Task<TransportCompany> UpdateTransportCompany(TransportCompany transportCompany)
        {
            transportCompany.Validate();

            var transportCompanyExists = _transportCompanyRepository.Get(transportCompany.Id);

            if (transportCompanyExists == null)
                throw new DomainException("A empresa de transporte informada não existe na base de dados.");

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
            _voucherRepository?.Dispose();
            _transportCompanyRepository?.Dispose();
            _orderRepository?.Dispose();
        }

        #endregion
    }
}
