using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Core.Data.Interfaces;
using CHStore.Application.Sales.Domain.Enums;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Status : Entity, IAggregateRoot
    {
        #region Properties

        public long OrderId { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        //EF Properties
        public Order Order { get; private set; }

        #endregion

        #region Constructors

        protected Status()
        {
        }

        public Status(long orderId, DateTime dateModified, OrderStatus orderStatus)
        {
            OrderId = orderId;
            OrderStatus = orderStatus;
        }

        #endregion

        #region Methods

        public bool Validate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
