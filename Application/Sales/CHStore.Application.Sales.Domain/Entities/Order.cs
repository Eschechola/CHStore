using System;
using System.Linq;
using System.Collections.Generic;
using CHStore.Application.Core.Data;
using CHStore.Application.Sales.Domain.Enums;
using CHStore.Application.Core.Data.Interfaces;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Order : Entity, IAggregateRoot
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
        
        private readonly List<OrderProduct> _orderProducts;
        public IReadOnlyCollection<OrderProduct> OrderProducts => _orderProducts;

        #endregion

        #region Navigation Properties

        public IList<Status> Status { get; private set; }
        public Voucher Voucher { get; private set; }
        public Customer Customer { get; private set; }
        public TransportCompany TransportCompany { get; private set; }

        #endregion

        #region Constructors
        protected Order(){}

        public Order(
            List<OrderProduct> orderProducts,
            Voucher voucher,
            TransportCompany transportCompany,
            decimal freightPrice,
            DateTime requestDate,
            PaymentMethod paymentMethod,
            List<Status> status
        )
        {
            _orderProducts = orderProducts;
            VoucherId = voucher.Id;
            TransportCompanyId = transportCompany.Id;
            Voucher = voucher;
            TransportCompany = transportCompany;
            FreightPrice = freightPrice;
            RequestDate = requestDate;
            PaymentMethod = paymentMethod;
            Status = status;

            CalculateProductsPrice();
            CalculateTotalPrice();
        }

        #endregion

        #region Methods

        public void AddProduct(OrderProduct orderProduct)
        {
            var productExists = OrderProducts
                .Where(x => x.ProductId == orderProduct.ProductId)
                .FirstOrDefault();

            if (productExists == null)
                _orderProducts.Add(orderProduct);

            CalculateProductsPrice();
            CalculateTotalPrice();
        }

        public void RemoveProduct(OrderProduct orderProduct)
        {
            var productExists = OrderProducts
                .Where(x => x.ProductId == orderProduct.ProductId)
                .FirstOrDefault();

            if (productExists == null)
                _orderProducts.Remove(orderProduct);

            CalculateProductsPrice();
            CalculateTotalPrice();
        }

        public void UpdateProduct(OrderProduct orderProduct)
        {
            var productExists = OrderProducts
                .Where(x => x.ProductId == orderProduct.ProductId)
                .FirstOrDefault();

            if (productExists == null)
            {
                _orderProducts.Remove(productExists);
                AddProduct(orderProduct);
            }

            CalculateProductsPrice();
            CalculateTotalPrice();
        }

        public void CalculateProductsPrice()
        {
            ProductsPrice = _orderProducts.Sum(x => x.Product.Price * x.Mount);
        }

        public void CalculateTotalPrice()
        {
            //desconto de acordo com a % do cupom de desconto

            var totalPrice = _orderProducts.Sum(x => x.Product.Price * x.Mount);

            if(Voucher != null)
            {
                //não existe pedido com o valor negativo
                var valueWithDiscount = totalPrice - (totalPrice * (Voucher.DiscountPercentage / 100));

                if (valueWithDiscount > 0)
                    totalPrice = valueWithDiscount;
            }
                
            
            totalPrice += FreightPrice;

            TotalPrice = totalPrice;
        }

        public void ChangeOrderStatus(Status status) => Status.Add(status);

        public void ChangeFinishDate(DateTime finishDate) => FinishDate = finishDate;

        public bool Validate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
