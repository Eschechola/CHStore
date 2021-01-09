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

        Task<VoucherDTO> AddVoucher(VoucherDTO voucherDTO);
        Task<VoucherDTO> UpdateVoucher(VoucherDTO voucherDTO);
        Task<IList<VoucherDTO>> GetVouchers();
        Task<VoucherDTO> GetVoucher(long voucherId);
        Task ActivateVoucher(VoucherDTO voucher);
        Task DeactivateVoucher(VoucherDTO voucher);

        Task<TransportCompanyDTO> AddTransportCompany(TransportCompanyDTO transportCompanyDTO);
        Task<TransportCompanyDTO> UpdateTransportCompany(TransportCompanyDTO transportCompanyDTO);
        Task<TransportCompanyDTO> GetTransportCompany(long transportCompanyId);
        Task<IList<TransportCompanyDTO>> SearchTransportCompanyByName(string name);
        Task ActivateTransportCompany(TransportCompanyDTO transportCompanyDTO);
        Task DeactivateTransportCompany(TransportCompanyDTO transportCompanyDTO);
    }
}
