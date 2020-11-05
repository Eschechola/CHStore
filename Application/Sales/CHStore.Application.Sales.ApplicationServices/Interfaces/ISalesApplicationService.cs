using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.ApplicationServices.DTO;

namespace CHStore.Application.Sales.ApplicationServices.Interfaces
{
    public interface ISalesApplicationService
    {
        Task<OrderDTO> CreateOrder(OrderDTO order);
        Task<OrderDTO> GetOrder(long orderId);
        Task<IList<OrderDTO>> GetAllOrders();
        Task<OrderDTO> UpdateOrderStatus(long orderId, StatusDTO status);
        Task<IList<OrderDTO>> SearchOrdersByCustomerId(long customerId);
        Task<IList<OrderDTO>> SearchOrderBetweenDates(DateTime initialDate, DateTime finalDate);
        Task<IList<OrderDTO>> SearchOrderBetweenPrices(decimal initialPrice, decimal finalPrice);
        Task<IList<OrderDTO>> SearchOrderByStatus(StatusDTO status);

        Task<VoucherDTO> AddVoucher(VoucherDTO voucherDTO);
        Task<VoucherDTO> UpdateVoucher(VoucherDTO voucherDTO);
        Task<IList<VoucherDTO>> GetVouchers();
        Task<VoucherDTO> GetVoucher(long voucherId);
        Task<IList<VoucherDTO>> SearchVoucherByCode(string code);
        Task<IList<VoucherDTO>> SearchVoucherByCode(string code, bool searchActives);
        Task<IList<VoucherDTO>> SearchVoucherBetweenDates(DateTime initialDate, DateTime finalDate);
        Task ActivateVoucher(VoucherDTO voucher);
        Task DeactivateVoucher(VoucherDTO voucher);

        Task<TransportCompanyDTO> AddTransportCompany(TransportCompanyDTO transportCompanyDTO);
        Task<TransportCompanyDTO> UpdateTransportCompany(TransportCompanyDTO transportCompanyDTO);
        Task ActivateTransportCompany(TransportCompanyDTO transportCompanyDTO);
        Task DeactivateTransportCompany(TransportCompanyDTO transportCompanyDTO);
    }
}
