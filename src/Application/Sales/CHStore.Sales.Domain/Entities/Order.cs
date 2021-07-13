using System;
using System.Linq;
using System.Collections.Generic;
using CHStore.Application.Core.Data;
using CHStore.Application.Sales.Domain.Enums;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Sales.Domain.Validators;
using CHStore.Application.Core.Exceptions;

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

        // EF Properties
        public IList<Status> Status { get; private set; }
        public Voucher Voucher { get; private set; }
        public Customer Customer { get; private set; }
        public TransportCompany TransportCompany { get; private set; }

        #endregion

        #region Constructors
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
            var validator = new OrderValidator();
            var validation = validator.Validate(this);

            if (validation.Errors.Count > 0)
                throw new DomainException(validation.Errors[0].ErrorMessage);

            return true;
        }

        #endregion
    }
}
