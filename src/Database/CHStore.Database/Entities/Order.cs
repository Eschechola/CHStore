using System;
using System.Collections.Generic;
using CHStore.Database.Enums;

namespace CHStore.Database.Entities
{
    public class Order : Entity
    {
        public long CustomerId { get; private set; }
        public long TransportCompanyId { get; private set; }
        public long VoucherId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal ProductsPrice { get; private set; }
        public decimal FreightPrice { get; private set; }
        public DateTime RequestDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        
        private readonly List<OrderProduct> _orderProducts;
        public IReadOnlyCollection<OrderProduct> OrderProducts => _orderProducts;

        // EF.
        public IList<Status> Status { get; private set; }
        public Voucher Voucher { get; private set; }
        public Customer Customer { get; private set; }
        public TransportCompany TransportCompany { get; private set; }

        protected Order()
        {
        }

        public Order(
            long customerId,
            long transportCompanyId,
            long voucherId,
            decimal totalPrice,
            decimal productsPrice,
            decimal freightPrice,
            DateTime finishDate,
            DateTime? requestDate = null,
            List<OrderProduct> orderProducts = null, 
            TransportCompany transportCompany = null,
            Voucher voucher = null)
        {
            CustomerId = customerId;
            TransportCompanyId = transportCompanyId;
            VoucherId = voucherId;
            TotalPrice = totalPrice;
            ProductsPrice = productsPrice;
            FreightPrice = freightPrice;
            FinishDate = finishDate;
            RequestDate = requestDate ?? DateTime.Now;
            TransportCompany = transportCompany;
            Voucher = voucher;
            
            _orderProducts = orderProducts ?? new List<OrderProduct>();
        }
    }
}
