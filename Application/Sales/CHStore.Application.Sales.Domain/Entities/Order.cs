using System;
using System.Linq;
using System.Collections.Generic;
using CHStore.Application.Core.Data;
using CHStore.Application.Sales.Domain.Enums;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Order : Entity
    {
        #region Properties

        public long CustomerId { get; private set; }
        public long TransportCompanyId { get; private set; }
        public long VoucherId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal ProductsPrice { get; private set; }
        public decimal FreightPrice { get; private set; }
        public DateTime RequestDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        #endregion

        #region Navigation Properties

        public IList<Status> Status { get; private set; }
        public Voucher Voucher { get; private set; }
        public Customer Customer { get; private set; }
        public TransportCompany TransportCompany { get; private set; }
        public IList<OrderProduct> OrderProducts { get; private set; }

        #endregion

        #region Constructors
        protected Order(){}

        public Order(
            IList<OrderProduct> orderProducts,
            Voucher voucher,
            TransportCompany transportCompany,
            decimal freightPrice,
            DateTime requestDate,
            PaymentMethod paymentMethod,
            IList<Status> status
        )
        {
            OrderProducts = orderProducts;
            VoucherId = voucher.Id;
            TransportCompanyId = transportCompany.Id;
            Voucher = voucher;
            TransportCompany = transportCompany;
            FreightPrice = freightPrice;
            RequestDate = requestDate;
            PaymentMethod = paymentMethod;
            Status = status;

            ProductsPrice = GetProductsPrice(orderProducts);
            TotalPrice = GetTotalPrice(orderProducts, voucher, freightPrice);
        }

        #endregion

        #region Methods

        private decimal GetProductsPrice(IList<OrderProduct> orderProducts)
        {
            return orderProducts.Sum(x => x.Product.Price * x.Mount);
        }

        private decimal GetTotalPrice(IList<OrderProduct> orderProducts, Voucher voucher, decimal freightPrice)
        {
            //desconto de acordo com a % do cupom de desconto

            var totalValue = orderProducts.Sum(x => x.Product.Price * x.Mount);

            if(voucher != null)
                totalValue -= totalValue - (voucher.DiscountPercentage / 100);
            
            totalValue += freightPrice;

            return totalValue;
        }

        public void ChangeOrderStatus(Status status) => Status.Add(status);

        public void ChangeFinishDate(DateTime finishDate) => FinishDate = finishDate;

        #endregion
    }
}
