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

        public long UserId { get; private set; }
        public long TransportCompanyId { get; private set; }
        public long CouponId { get; private set; }
        public decimal TotalPrice { get; private set; }
        public decimal ProductsPrice { get; private set; }
        public decimal FreightPrice { get; private set; }
        public DateTime RequestDate { get; private set; }
        public DateTime FinishDate { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        #endregion

        #region Navigation Properties

        public IList<Status> Status { get; private set; }
        public Coupon Coupon { get; private set; }
        public User User { get; private set; }
        public TransportCompany TransportCompany { get; private set; }
        public IList<OrderProduct> OrderProducts { get; private set; }

        #endregion

        #region Constructors
        protected Order(){}

        public Order(
            IList<OrderProduct> orderProducts,
            Coupon coupon,
            TransportCompany transportCompany,
            decimal freightPrice,
            DateTime requestDate,
            PaymentMethod paymentMethod,
            IList<Status> status
        )
        {
            OrderProducts = orderProducts;
            CouponId = coupon.Id;
            TransportCompanyId = transportCompany.Id;
            Coupon = coupon;
            TransportCompany = transportCompany;
            FreightPrice = freightPrice;
            RequestDate = requestDate;
            PaymentMethod = paymentMethod;
            Status = status;

            ProductsPrice = GetProductsPrice(orderProducts);
            TotalPrice = GetTotalPrice(orderProducts, coupon, freightPrice);
        }

        #endregion

        #region Methods

        private decimal GetProductsPrice(IList<OrderProduct> orderProducts)
        {
            return orderProducts.Sum(x => x.Product.Price * x.Mount);
        }

        private decimal GetTotalPrice(IList<OrderProduct> orderProducts, Coupon coupon, decimal freightPrice)
        {
            //desconto de acordo com a % do cupom de desconto

            var totalValue = orderProducts.Sum(x => x.Product.Price * x.Mount);

            if(coupon != null)
                totalValue -= totalValue - (coupon.DiscountPercentage / 100);
            
            totalValue += freightPrice;

            return totalValue;
        }

        public void ChangeOrderStatus(Status status) => Status.Add(status);

        public void ChangeFinishDate(DateTime finishDate) => FinishDate = finishDate;

        #endregion
    }
}
