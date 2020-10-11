using System;
using System.Linq;
using System.Collections.Generic;
using CHStore.Application.Core.Data;
using CHStore.Application.Sales.Domain.Enums;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Order : Entity
    {
        public long TransportCompanyId { get; private set; }
        public long CouponId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal ProductsPrice { get; private set; }
        public decimal FreightPrice { get; private set; }
        public DateTime RequestDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public OrderStatus Status { get; private set; }


        public Coupon Coupon { get; private set; }
        public TransportCompany TransportCompany { get; private set; }
        public IList<Product> Products { get; private set; }

        public Order(
            IList<Product> products,
            Coupon coupon,
            TransportCompany transportCompany,
            decimal freightPrice,
            DateTime requestDate,
            PaymentMethod paymentMethod,
            OrderStatus status
        )
        {
            Products = products;
            CouponId = coupon.Id;
            TransportCompanyId = transportCompany.Id;
            Coupon = coupon;
            TransportCompany = transportCompany;
            FreightPrice = freightPrice;
            RequestDate = requestDate;
            PaymentMethod = paymentMethod;
            Status = status;

            ProductsPrice = GetProductsPrice(products);
            TotalPrice = GetTotalPrice(products, coupon, freightPrice);
        }

        private decimal GetProductsPrice(IList<Product> products)
        {
            return products.Sum(x => x.Price * x.Mount);
        }

        private decimal GetTotalPrice(IList<Product> products, Coupon coupon, decimal freightPrice)
        {
            //desconto de acordo com a % do cupom de desconto

            var totalValue = products.Sum(x => x.Price * x.Mount);

            totalValue -= totalValue - (coupon.DiscountPercentage / 100);
            totalValue += freightPrice;

            return totalValue;
        }

        public void ChangeOrderStatus(OrderStatus status) => Status = status;

        public void ChangeFinishDate(DateTime finishDate) => FinishDate = finishDate;
    }
}
