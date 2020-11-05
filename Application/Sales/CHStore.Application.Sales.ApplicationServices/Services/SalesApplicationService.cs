using System;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Sales.ApplicationServices.DTO;
using CHStore.Application.Sales.DomainServices.Interfaces;
using CHStore.Application.Sales.ApplicationServices.Interfaces;

namespace CHStore.Application.Sales.ApplicationServices.Services
{
    public class SalesApplicationService : ISalesApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ISalesDomainService _salesDomainService;

        public SalesApplicationService(IMapper mapper, ISalesDomainService salesDomainService)
        {
            _mapper = mapper;
            _salesDomainService = salesDomainService;
        }

        #region Order

        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);

            var orderInserted = await _salesDomainService.CreateOrder(order);

            return _mapper.Map<OrderDTO>(orderInserted);
        }
        public async Task<OrderDTO> UpdateOrderStatus(long orderId, StatusDTO statusDTO)
        {
            var status = _mapper.Map<Status>(statusDTO);

            var orderUpdated = await _salesDomainService.UpdateOrderStatus(orderId, status);

            return _mapper.Map<OrderDTO>(orderUpdated);
        }

        public async Task<IList<OrderDTO>> GetAllOrders()
        {
            var allOrders = await _salesDomainService.GetAllOrders();

            return _mapper.Map<IList<OrderDTO>>(allOrders);
        }

        public async Task<OrderDTO> GetOrder(long orderId)
        {
            var order = await _salesDomainService.GetOrder(orderId);

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<IList<OrderDTO>> SearchOrderByStatus(StatusDTO statusDTO)
        {
            var status = _mapper.Map<Status>(statusDTO);
            var orders = await _salesDomainService.SearchOrderByStatus(status);

            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<IList<OrderDTO>> SearchOrderBetweenPrices(decimal initialPrice, decimal finalPrice)
        {
            var orders = await _salesDomainService.SearchOrderBetweenPrices(initialPrice, finalPrice);

            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<IList<OrderDTO>> SearchOrdersByCustomerId(long customerId)
        {
            var orders = await _salesDomainService.SearchOrdersByCustomerId(customerId);

            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        public async Task<IList<OrderDTO>> SearchOrderBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            var orders = await _salesDomainService.SearchOrderBetweenDates(initialDate, finalDate);

            return _mapper.Map<IList<OrderDTO>>(orders);
        }

        #endregion

        #region Voucher

        public async Task<VoucherDTO> AddVoucher(VoucherDTO voucherDTO)
        {
            var voucher = _mapper.Map<Voucher>(voucherDTO);

            var voucherInserted = await _salesDomainService.AddVoucher(voucher);

            return _mapper.Map<VoucherDTO>(voucherInserted);
        }
        public async Task<VoucherDTO> UpdateVoucher(VoucherDTO voucherDTO)
        {
            var voucher = _mapper.Map<Voucher>(voucherDTO);

            var voucherUpdated = await _salesDomainService.UpdateVoucher(voucher);

            return _mapper.Map<VoucherDTO>(voucherUpdated);
        }

        public async Task ActivateVoucher(VoucherDTO voucherDTO)
        {
            var voucher = _mapper.Map<Voucher>(voucherDTO);

            voucher.ActivateVoucher();

            await UpdateVoucher(_mapper.Map<VoucherDTO>(voucher));
        }

        public async Task DeactivateVoucher(VoucherDTO voucherDTO)
        {
            var voucher = _mapper.Map<Voucher>(voucherDTO);

            voucher.DeactivateVoucher();

            await UpdateVoucher(_mapper.Map<VoucherDTO>(voucher));
        }

        public async Task<VoucherDTO> GetVoucher(long voucherId)
        {
            var voucher = await _salesDomainService.GetVoucher(voucherId);

            return _mapper.Map<VoucherDTO>(voucher);
        }

        public async Task<IList<VoucherDTO>> GetVouchers()
        {
            var allVouchers = await _salesDomainService.GetVouchers();

            return _mapper.Map<IList<VoucherDTO>>(allVouchers);
        }

        public async Task<IList<VoucherDTO>> SearchVoucherBetweenDates(DateTime initialDate, DateTime finalDate)
        {
            var allVouchers = await _salesDomainService.SearchOrderBetweenDates(initialDate, finalDate);

            return _mapper.Map<IList<VoucherDTO>>(allVouchers);
        }
        
        public async Task<IList<VoucherDTO>> SearchVoucherByCode(string code)
        {
            var allVouchers = await _salesDomainService.SearchVoucherByCode(code);

            return _mapper.Map<IList<VoucherDTO>>(allVouchers);
        }

        public async Task<IList<VoucherDTO>> SearchVoucherByCode(string code, bool searchActives)
        {
            var allVouchers = await _salesDomainService.SearchVoucherByCode(code, searchActives);

            return _mapper.Map<IList<VoucherDTO>>(allVouchers);
        }

        #endregion

        #region TransportCompany

        public async Task<TransportCompanyDTO> AddTransportCompany(TransportCompanyDTO transportCompanyDTO)
        {
            var transportCompany = _mapper.Map<TransportCompany>(transportCompanyDTO);

            var transportCompanyInserted = await _salesDomainService.AddTransportCompany(transportCompany);

            return _mapper.Map<TransportCompanyDTO>(transportCompanyInserted);
        }

        public async Task<TransportCompanyDTO> UpdateTransportCompany(TransportCompanyDTO transportCompanyDTO)
        {
            var transportCompany = _mapper.Map<TransportCompany>(transportCompanyDTO);

            var transportCompanyUpdated = await _salesDomainService.UpdateTransportCompany(transportCompany);

            return _mapper.Map<TransportCompanyDTO>(transportCompanyUpdated);
        }

        public async Task ActivateTransportCompany(TransportCompanyDTO transportCompanyDTO)
        {
            var transportCompany = _mapper.Map<TransportCompany>(transportCompanyDTO);
            transportCompany.ActivateTransportCompany();

            await UpdateTransportCompany(_mapper.Map<TransportCompanyDTO>(transportCompany));
        }

        public async Task DeactivateTransportCompany(TransportCompanyDTO transportCompanyDTO)
        {
            var transportCompany = _mapper.Map<TransportCompany>(transportCompanyDTO);
            transportCompany.DeactivateTransportCompany();

            await UpdateTransportCompany(_mapper.Map<TransportCompanyDTO>(transportCompany));
        }

        #endregion
    }
}
