using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Entities;
using CHStore.Application.Core.Filters;

namespace CHStore.Application.Sales.DomainServices.Interfaces
{
    public interface ISalesDomainService
    {
        Task<Order> CreateOrder(Order order);
        Task<Order> GetOrder(long orderId);
        Task<IList<Order>> GetAllOrders();
        Task<Order> UpdateOrderStatus(long orderId, Status status);
        Task<IList<Order>> SearchOrders(SearchOrderFilter searchFilter);

        Task<Voucher> AddVoucher(Voucher voucher);
        Task<Voucher> UpdateVoucher(Voucher voucher);
        Task<IList<Voucher>> GetVouchers();
        Task<Voucher> GetVoucher(long voucherId);
        Task<IList<Voucher>> SearchVoucher(SearchVoucherFilter searchFilter);
        Task ActivateVoucher(Voucher voucher);
        Task DeactivateVoucher(Voucher voucher);

        Task<TransportCompany> AddTransportCompany(TransportCompany transportCompany);
        Task<TransportCompany> UpdateTransportCompany(TransportCompany transportCompany);
        Task ActivateTransportCompany(TransportCompany transportCompany);
        Task DeactivateTransportCompany(TransportCompany transportCompany);
    }
}
