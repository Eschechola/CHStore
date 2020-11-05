using System;
using System.Collections.Generic;
using CHStore.Application.Sales.Domain.Enums;

namespace CHStore.Application.Sales.ApplicationServices.DTO
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long TransportCompanyId { get; set; }
        public long VoucherId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ProductsPrice { get; set; }
        public decimal FreightPrice { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime FinishDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public IList<StatusDTO> Status { get; set; }
        public VoucherDTO Voucher { get; set; }
        public CustomerDTO Customer { get; set; }
        public TransportCompanyDTO TransportCompany { get; set; }
        public IList<OrderProductDTO> OrderProducts { get; set; }
    }
}
