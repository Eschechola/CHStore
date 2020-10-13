using System;
using CHStore.Application.Core.Data;
using CHStore.Application.Sales.Domain.Enums;

namespace CHStore.Application.Sales.Domain.Entities
{
    public class Status : Entity
    {
        public long OrderId { get; private set; }
        public DateTime DateModified { get; private set; }
        public OrderStatus OrderStatus { get; private set; }

        public Order Order { get; private set; }

        public Status(long orderId, DateTime dateModified, OrderStatus orderStatus)
        {
            OrderId = orderId;
            DateModified = dateModified;
            OrderStatus = orderStatus;
        }
    }
}
